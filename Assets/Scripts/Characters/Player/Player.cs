using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StatsManager))]
[RequireComponent (typeof(SkillCastManager))]
public class Player : MonoBehaviour
{
    //private StatsManager stats;
    private SkillCastManager skillCastManager;
    public static Player instance;

    //[SerializeField] BulletSkill testBulletSkill;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else GameObject.Destroy(this);
        //stats ??= GetComponent<StatsManager>();
        //skillCastManager ??= GetComponent<SkillCastManager>();
        //skillCastManager.skills.Push(testBulletSkill);
    }

    private void Attack()
    {
    }

    //private void OnValidate()
    //{
    //    stats ??= GetComponent<StatsManager>();
    //}
}