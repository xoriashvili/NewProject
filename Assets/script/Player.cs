using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using Unity.Burst.CompilerServices;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour  
{
    #region vars
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] Joystick joystick;
    [SerializeField] Rigidbody rb;
    public int Heal;
    [SerializeField] float Distance;
    private EnemyControler Enemy;
    [SerializeField] int Damage;
    [SerializeField] GameObject log;
    [SerializeField] TextMeshProUGUI Text;
    public int Bag;
    [SerializeField] Image HealBar;
    [SerializeField] Transform AttackPoint;
    [SerializeField] Vector3 AttackRAnge;
    [SerializeField] LayerMask TargetLayer;

    float MaxHeal;
    #endregion

    #region unityfunction


    void Start()
    {
        MaxHeal = Heal;
    }
    private void Update()
    {
        Text.text = Bag.ToString(); 
        if(Heal <= 0)
        {
            SceneManager.LoadScene(1);
        }

        float loss = Heal * 100 / MaxHeal;
        HealBar.fillAmount = 1 * loss / 100;
        
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
        CheckEnemy();




    }
    #endregion

    #region myFunction
    private void Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);

        
    }

    private void Rotate()
    {
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            animator.SetBool("Walk", true);

            transform.rotation = Quaternion.LookRotation(new Vector3(joystick.Horizontal, 0, joystick.Vertical));
        }
        else
        {
           
            animator.SetBool("Walk", false);
        }
       
    }
    
    private  void CheckEnemy()
    {
       var Enemy = Physics.OverlapBox(AttackPoint.position, AttackRAnge,quaternion.identity,TargetLayer);
       if(Enemy.Length != 0)
       {
            if (Enemy[0].transform.tag == "Enemy" || Enemy[0].transform.tag == "Tree")
            {
                animator.SetTrigger("Attack");
            }
           
       }
      
        
    }
    public void Attack()
    {

        var Enemy = Physics.OverlapBox(AttackPoint.position, AttackRAnge, quaternion.identity, TargetLayer);
        if (Enemy.Length != 0)
        {
            if (Enemy[0].transform.tag == "Enemy")
            {
                Enemy[0].GetComponent<EnemyControler>().Heal -= Damage;
            }
            else if (Enemy[0].transform.tag == "Tree")
            {
                StartCoroutine(Enemy[0].transform.gameObject.GetComponent<TreeControler>().CutSimulator());
                Enemy[0].transform.gameObject.GetComponent<TreeControler>().Heal--;

                for (int i = 0; i < 2; i++)
                {

                    GameObject Tlog = Instantiate(log,new Vector3(Enemy[0].transform.position.x, Enemy[0].transform.position.y + 1, Enemy[0].transform.position.z), Quaternion.identity);
                    Tlog.GetComponent<Rigidbody>().velocity = new Vector3(0, 3, 0);

                }
            }
        }
        
           
        
        

    }


    #endregion

    
}
