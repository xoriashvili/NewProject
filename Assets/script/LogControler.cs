using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogControler : MonoBehaviour
{
    public Transform bag;
    public Rigidbody Rb;
    int Counter;
    void Start()
    {

       

        bag = FindObjectOfType<Player>().transform.GetChild(6);
        
    }


    void FixedUpdate()
    {
        Counter++;
        if (Counter >= 20)
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = Vector3.Lerp(transform.position, bag.position, 0.1f);
            transform.GetComponent<MeshCollider>().isTrigger = true;
            
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" ) 
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>().Bag++;
        
        }
    }




}
