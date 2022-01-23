using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExecuter : MonoBehaviour, IEventExecuter
{
    
    public void ExecuterEvent(int idEvent)
    {
        Debug.Log(idEvent);
    }
}
