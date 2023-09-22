using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyControler : MonoBehaviour
{
    #region vars
     [SerializeField] NavMeshAgent agent;
     [SerializeField] float Range;
     [SerializeField] Animator animator;
     public int Heal;
     [SerializeField] int Damage;
     [SerializeField] GameObject Player;
     [SerializeField] Rigidbody rb;
    float MaxHeal;
     [SerializeField] Image HealBar;
    #endregion


    #region unityfunction
    void Start()
    {
        MaxHeal = Heal;
    }
   

    void FixedUpdate()
    {
        AttackAnimation();

       
        
        if(Heal <= 0)
        {
            Destroy(gameObject);
        }

        float loss = Heal * 100 / MaxHeal;
        HealBar.fillAmount = 1 * loss / 100;
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
