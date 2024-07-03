using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStatsManager : StatsManager
{
    [SerializeField] private EnemyStats stats;
    
    public override float MaxHealth => stats.MaxHealth + stats.MaxHealth * GameSessionManager.instance.Level * 0.1f;
    public override float Speed => stats.Speed;
    public override float Attack => stats.Attack;

}
