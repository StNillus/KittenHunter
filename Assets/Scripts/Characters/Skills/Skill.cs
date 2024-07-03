using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] public float cooldown;
    //public float lastTimeCasted;
    public abstract void Cast(GameObject parent, bool isOwnedByPlayer, StatsManager baseStats);
    //public abstract bool CanCast();
}
