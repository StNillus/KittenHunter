using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[RequireComponent(typeof(StatsManager))]
public class SkillCastManager : MonoBehaviour
{
    [SerializeField] Dictionary<Skill, float> skillTimeCasted;
    [SerializeField] List<Skill> skills;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private StatsManager stats;
    private bool isOwnedByPlayer;
    private int lastCastedSkillIndex;
    private bool castingSpell = false;
    private void Update()
    {
        foreach (Skill skill in skills)
        {
            if (Time.time > skillTimeCasted[skill] + skill.cooldown && !castingSpell)
                StartCoroutine(CastSkill(skill));
            
        }
    }

    private IEnumerator CastSkill(Skill skill)
    {
        castingSpell = true;
        skillTimeCasted[skill] = Time.time;
        yield return new WaitForSeconds(0.3f);
        skill.Cast(spawnPoint, isOwnedByPlayer, stats);
        castingSpell = false;
    }
    private void Awake()
    {
        //Debug.Log($"isOwnedByPlayer: {isOwnedByPlayer}, StatsManager type: {this.GetComponent<StatsManager>().GetType()}");
        stats ??= GetComponent<StatsManager>();
        //skills = new Stack<Skill>();
        //skills.Push(stats.Skill);
        isOwnedByPlayer = stats.GetType() == typeof(PlayerStatsManager_Test);
        skillTimeCasted = new Dictionary<Skill, float>();
        skills.ForEach(skill => { skillTimeCasted[skill] = Time.time; });
    }
    


}
