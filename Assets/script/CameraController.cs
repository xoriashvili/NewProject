using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float speed;

    void Start()
    {
        transform.LookAt(Player);
    }


    void Update()
    {
      
        if(Player != null)
        {
          transform.position = Vector3.Lerp(transform.position, new Vector3(Player.position.x,Player.position.y + 4,Player.position.z - 3), speed);
        }
           
     



    }
}
