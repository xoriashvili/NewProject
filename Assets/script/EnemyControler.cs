using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour
{
    #region vars
    public NavMeshAgent agent;
    public float Range;
    public Animator animator;
    public int Heal;
    public int Damage;
    public GameObject Player;
    public Rigidbody rb;
    #endregion


    #region unityfunction
    void Start()
    {
        
    }
   

    void FixedUpdate()
    {
        AttackAnimation();

       
        
        if(Heal <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region MyFunction
    public void Attack()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward,out hit,Range))
        {
            if(hit.transform.tag == "Player")
            {
                hit.transform.GetComponent<Player>().Heal -= Damage;
            }
            
            
        }
        
    }
    private void AttackAnimation()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(new Vector3 (transform.position.x,transform.position.y+0.5f,transform.position.z), transform.forward, out hit, Range))
        {
            
            if (hit.transform.tag == "Player")
            {
                
                animator.SetTrigger("Attack");
            }
           
 
        }
        else if (Player != null && Vector3.Distance(transform.position,Player.transform.position) > Range)
        {
            agent.SetDestination(Player.transform.position);
        }
        if ((hit.transform == null || hit.transform.tag != "Player") && Player != null && Vector3.Distance(transform.position, Player.transform.position) < Range)
        {
            Vector3 direction = Player.transform.position - transform.position;
            float angel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angel, 0);
           
            
        }
    }
    #endregion
    

}
