using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICastableSkill
{
    void Cast(GameObject parent, bool isOwnedByPlayer, StatsManager baseStats);
}
