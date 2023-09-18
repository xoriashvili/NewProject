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

public class Player : MonoBehaviour  
{
    #region vars
    public float speed;
    public Animator animator;
    public Joystick joystick;
    public Rigidbody rb;
    public int Heal;
    public float Distance;
    private EnemyControler Enemy;
    public int Damage;
    public GameObject log;
    public TextMeshProUGUI Text;
    public int Bag;
    #endregion

    #region unityfunction


    void Start()
    {
        
    }
    private void Update()
    {
        Text.text = Bag.ToString(); 
        if(Heal <= 0)
        {
            Destroy(gameObject);
        }
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

    private void CheckEnemy()
    {
        RaycastHit hit;

        if (Physics.Raycast(new Vector3(transform.position.x,transform.position.y+1,transform.position.z),transform.forward,out hit,Distance))
        {
            
            if (hit.transform.gameObject.tag == "Enemy")
            {
                
                animator.SetTrigger("Attack");
                Enemy = hit.transform.GetComponent<EnemyControler>();
                
            }else if(hit.transform.gameObject.tag == "Tree")
            {
                animator.SetTrigger("Attack");
                
            }
            
        }
        
    }
    public void Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward, out hit, Distance))
        {

            if (hit.transform.gameObject.tag == "Enemy")
            {

                Enemy.Heal -= Damage;

            }else if(hit.transform.gameObject.tag == "Tree")
            {
                StartCoroutine(hit.transform.gameObject.GetComponent<TreeControler>().CutSimulator());
                hit.transform.gameObject.GetComponent<TreeControler>().Heal--;
                
               for (int i = 0; i < 2; i++)
               {
             
                  GameObject Tlog = Instantiate(log, hit.point, Quaternion.identity);
                    Tlog.GetComponent<Rigidbody>().velocity = new Vector3(0, 3, 0);

               }
            }
           
        }
        

    }
    
    
    #endregion


}
