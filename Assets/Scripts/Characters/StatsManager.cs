using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    //[SerializeField] public Skill Skill;
    [SerializeField] private GameEvent DeathEvent;
    [SerializeField] private float currentHealth;
    public virtual float MaxHealth { get; }
    public virtual float Speed { get; }
    public virtual float Attack { private set; get; }
    public void ResetHealth()
    {
        currentHealth = MaxHealth;
    }

    private void OnEnable()
    {
        ResetHealth();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DeathEvent.TriggerEvent(this.GameObject());
        }
            
    }
}
