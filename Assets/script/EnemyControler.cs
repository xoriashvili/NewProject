using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour
{
    #region vars
    public NavMeshAgent agent;
    public float Range;
    private GameObject Player;
    public Animator animator;
    public int Heal;
    public int Damage;
    
    #endregion


    #region unityfunction
    void Start()
    {
        
    }
    private void Awake()
    {
        Player = FindAnyObjectByType<Player>().gameObject;
    }

    void Update()
    {
        

        if (Vector3.Distance(transform.position, Player.transform.position) < Range)
        {
            animator.SetTrigger("Attack");

        }
        else
        {
            agent.SetDestination(Player.transform.position);
        }
        
        if(Heal <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region MyFunction
    public void Attack()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < Range)
        {
            
            Player.GetComponent<Player>().Heal -= Damage;
        }
        
    }
    #endregion


}
