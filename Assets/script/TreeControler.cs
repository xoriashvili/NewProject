using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeControler : MonoBehaviour
{
    #region vars
    public int Heal;
    bool IsCut;
    #endregion

    #region UnityFunction

    void Start()
    {
        
    }

    void Update()
    {

        
            CutTree();
        
        
    }

    #endregion

    #region MyFunction
    void CutTree()
    {
        if (Heal <= 0 && ! IsCut)
        {
            transform.AddComponent<Rigidbody>();
            IsCut = true;

            Destroy(transform.GetChild(0).gameObject);
            gameObject.tag = "DestroyTree";
            Destroy(gameObject, 2);
        }
    }
   public IEnumerator CutSimulator()
    {
        transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
        yield return new WaitForSeconds(0.1f);
        transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
    }
    #endregion

}
