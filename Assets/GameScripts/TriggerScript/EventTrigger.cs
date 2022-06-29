using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(myEvent == null)
        {
            print(" myEvent TriggerOnEnter was triggered But my event was null");
        }
        else
        {
            print("my event Trigger on Enter Activated. Triggering" + myEvent);
            myEvent.Invoke();
        }
    }
}
