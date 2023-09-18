using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class AnimationEvent : MonoBehaviour
{
    [System.Serializable]
    public class AnimEvent
    {
        public string Attack;
        public UnityEvent CallEvent;

    }
   
    public AnimEvent[] Animevent;
    public void SendEvent(string CallName)
    {
        foreach (var Event in Animevent)
        {

            if (CallName == Event.Attack)
            {
                Event.CallEvent.Invoke();
            }
        }
    }


}
