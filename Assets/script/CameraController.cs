using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public float speed;

    void Start()
    {
        transform.LookAt(Player);
    }


    void Update()
    {
      

            transform.position = Vector3.Lerp(transform.position, new Vector3(Player.position.x,Player.position.y + 4,Player.position.z - 3), speed);
     



    }
}
