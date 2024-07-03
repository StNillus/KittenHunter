using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class BulletAutoTargetingSkill : BulletSkill
{
    [SerializeField] private float viewRange;
    public override void Fire(GameObject spawnParent, bool isOwnedByPlayer, float attack)
    {
        //Debug.Log("BulletAutoTargetingSkill");
        Collider[] enemyTargets = Physics.OverlapSphere(spawnParent.transform.position, viewRange);
        if (enemyTargets.Length > 0 )
        {
            Collider target = enemyTargets.Where(x => (x.tag == "Player" ^ isOwnedByPlayer) && !x.GetComponent<StatsManager>().IsUnityNull()).FirstOrDefault();
            if (target != null)
            {
                //Debug.Log($"target name: {target.name}");
                GameObject newBullet = ObjectPoolTest.instance.GetObject(bullet, spawnParent.transform);

                Vector3 targetPosition = new Vector3(target.transform.position.x, newBullet.transform.position.y, target.transform.position.z);
                targetPosition -= newBullet.transform.position;
                Vector3 direction = Vector3.MoveTowards(newBullet.transform.position, targetPosition, 100).normalized;
                newBullet.GetComponent<Bullet>().SetStats(attack, isOwnedByPlayer, direction);
            }
        }
        
        //base.Fire(spawnParent, isOwnedByPlayer, attack);
    }
}
