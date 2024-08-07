using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerStatsManager_Test : StatsManager
{
    public override float MaxHealth => 100;
    public override float Speed => 9;
    public override float Attack => 5;

    [SerializeField] BulletSkill testBulletSkill;
    [SerializeField] public Stack<ICastableSkill> skills;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<StatsManager>() != null)
            TakeDamage(other.GetComponent<StatsManager>().Attack);
    }
}
