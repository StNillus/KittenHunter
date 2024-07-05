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
    public static Player instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else GameObject.Destroy(this);
    }
}