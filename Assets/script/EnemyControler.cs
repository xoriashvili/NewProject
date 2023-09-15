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
        agent.SetDestination(Player.transform.position);

        if (Vector3.Distance(transform.position, Player.transform.position) < Range)
        {
            animator.SetTrigger("Attack");

        }
        
    }
    #endregion

    #region MyFunction
    public void Attack()
    {
        Player.GetComponent<Player>().Heal--;
    }
    #endregion


}
