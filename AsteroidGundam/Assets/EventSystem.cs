using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystem : MonoBehaviour
{
    [System.Serializable]

    public class EventWrapper
    {
        public UnityEvent unityEvent;
    }

    public EventWrapper[] unityEvents;

    public void InvokeAll()
    {
        foreach(EventWrapper eventWrapper in unityEvents)
        {
            eventWrapper.unityEvent.Invoke();
        }
    }

    public void TriggerEvent(int index)
    {
        if(index >= 0 && index < unityEvents.Length)
        {
            unityEvents[index].unityEvent.Invoke();
        }
    }
}
