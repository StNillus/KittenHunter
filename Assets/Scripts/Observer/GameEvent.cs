using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameObjectEventListener> listeners = new List<GameObjectEventListener> ();

    public void TriggerEvent(GameObject gameObject)
    {
        foreach (GameObjectEventListener listener in listeners)
        {
            listener.OnEventTriggered(gameObject);
        }
    }

    public void AddListener(GameObjectEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(GameObjectEventListener listener)
    {
        listeners.Remove(listener);
    }

}
