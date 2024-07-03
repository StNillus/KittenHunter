using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    public static GameSessionManager instance;
    [SerializeField] private float LevelUpTime;
    [SerializeField] private int level = 0;
    public int Level => level;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else GameObject.Destroy(this);
    }
    private void Start()
    {
        StartCoroutine(LevelUp());
    }
    private IEnumerator LevelUp()
    {
        yield return new WaitForSeconds(LevelUpTime);
        level++;
        Debug.Log($"level: {level}");
    }
}
