using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR;

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
    #endregion

    #region unityfunction


    void Start()
    {
        
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
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical *speed);
        
    }

    private void Rotate()
    {
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            animator.SetBool("Walk", true);
            
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
           
            animator.SetBool("Walk", false);
        }
       
    }

    private void CheckEnemy()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward,out hit,Distance))
        {
            if(hit.transform.gameObject.tag == "Enemy")
            {
                animator.SetTrigger("Attack");
                Enemy = hit.transform.GetComponent<EnemyControler>();

            }
        }
        Debug.DrawLine(transform.position,transform.forward);   
    }
    public void Attack()
    {
        Enemy.Heal--;

    }
    #endregion


}
