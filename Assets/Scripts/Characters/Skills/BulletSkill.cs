using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(StatsManager))]
[CreateAssetMenu]
public class BulletSkill : Skill
{
    [SerializeField] public GameObject bullet;
    
    [SerializeField] private float attackMultiplier;
    //public float lastTimeCasted;
    //[SerializeField] float cooldown;


    public override void Cast(GameObject spawnParent, bool isOwnedByPlayer, StatsManager baseStats)
    {
            Fire(spawnParent, isOwnedByPlayer, baseStats.Attack * attackMultiplier);
    }

    public virtual void Fire(GameObject spawnParent, bool isOwnedByPlayer, float attack)
    {
        GameObject _newBullet = ObjectPoolTest.instance.GetObject(bullet, spawnParent.transform);
        _newBullet.GetComponent<Bullet>().SetStats(attack * attackMultiplier, isOwnedByPlayer, spawnParent.transform.forward);
        //lastTimeCasted = Time.time;
    }
}
