using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeGrowing : MonoBehaviour
{
    public GameObject TreeChild;
    bool Growing;
    void Start()
    {
        Instantiate(TreeChild, transform);
    }


    void Update()
    {
      if(transform.childCount == 0 && !Growing)
      {
            StartCoroutine(GrowTime());
      }
        
    }
    IEnumerator GrowTime()
    {
        Growing = true;
        yield return new WaitForSeconds(5);
        Instantiate(TreeChild, transform);
    }

}
