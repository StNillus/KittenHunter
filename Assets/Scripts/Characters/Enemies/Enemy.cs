using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyStatsManager))]
public class Enemy : MonoBehaviour, IKnockbackAble
{
    private EnemyStatsManager stats;
    private Rigidbody rigibody;
    private Vector3 destination => Player.instance.transform.position;
    //[SerializeField] BulletSkill testBulletSkill;

    private void Update()
    {
        //follow player & Attack
        rigibody.transform.position = Vector3.MoveTowards(transform.position, destination, stats.Speed);

        Vector3 movementDirection = destination - transform.position;
        rigibody.velocity = movementDirection * stats.Speed;
        if (rigibody.velocity != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rigibody.rotation = Quaternion.RotateTowards(rigibody.rotation, rotation, 100);
        }
        //
    }

    private void OnEnable()
    {
        stats.ResetHealth();
    }

    private void Attack()
    {

    }

    private void Awake()
    {
        stats ??= GetComponent<EnemyStatsManager>();
        rigibody ??= GetComponent<Rigidbody>();
        //SkillCastManager skillCastManager = GetComponent<SkillCastManager>();
        //skillCastManager.skills.Push(testBulletSkill);
    }
    private void OnValidate()
    {
        stats ??= GetComponent<EnemyStatsManager>();
        rigibody ??= GetComponent<Rigidbody>();
        rigibody.interpolation = RigidbodyInterpolation.Interpolate;
        rigibody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Knockback(other.transform);
        if (other.GetComponent<StatsManager>() != null && other.tag != this.tag)
        {
            Debug.Log($"trigger enter & damage recved by {other.name}");
            stats.TakeDamage(other.GetComponent<StatsManager>().Attack);

        }
            
    }

    public void Knockback(Transform knockbackExecuterSource)
    {
        
        Vector3 direction = (transform.position - knockbackExecuterSource.position).normalized;
        rigibody.AddForce(direction * 100, ForceMode.Impulse);
    }
}
