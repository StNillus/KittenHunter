using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float attack;
    [SerializeField] private float attackRange;
    public float MaxHealth => maxHealth;
    public float Speed => speed;
    public float Attack => attack;
    public float AttackRange => attackRange;
}
