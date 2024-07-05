using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyStatsManager))]
[RequireComponent (typeof(ReturnToPoolWhenUnvisible))]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private EnemyStatsManager stats;
    private Rigidbody rigibody;
    private NavMeshAgent agent;
    private Vector3 destination => Player.instance.transform.position;
    //[SerializeField] BulletSkill testBulletSkill;

    private void Update()
    {
        transform.LookAt(destination);
        agent.destination = destination;
        //follow player & Attack
        //rigibody.transform.position = Vector3.MoveTowards(transform.position, destination, stats.Speed);

        //Vector3 movementDirection = destination - transform.position;
        //rigibody.velocity = movementDirection * stats.Speed;
        //if (rigibody.velocity != Vector3.zero)
        //{
        //    Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    rigibody.rotation = Quaternion.RotateTowards(rigibody.rotation, rotation, 100);
        //}
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
        ReturnToPoolWhenUnvisible returnToPool = GetComponent<ReturnToPoolWhenUnvisible>();
        returnToPool.TimeBeforeReturn = 3.0f;
        agent ??= GetComponent<NavMeshAgent>();
        agent.speed = stats.Speed;
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

    //private void OnTriggerEnter(Collider other)
    //{   
    //    Knockback(other.transform);
    //    if (other.GetComponent<StatsManager>() != null && other.tag != this.tag)
    //    {
    //        Debug.Log($"trigger enter & damage recved by {other.name}");
    //        stats.TakeDamage(other.GetComponent<StatsManager>().Attack);
    //    }
    //}

}
