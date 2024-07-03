using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public GameObjectEvent onEventTriggered;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered(GameObject gameObject)
    {
        onEventTriggered.Invoke(gameObject);
    }

}
