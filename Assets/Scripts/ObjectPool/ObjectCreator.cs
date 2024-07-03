using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private float cooldown = 1.0f;
    [SerializeField] private ObjectPoolTest objectPool;
    private List<GameObject> enemies = new List<GameObject>();
    private float coldownTimer;

    private void Update()
    {
        //enemies.ForEach(e => { e.GetComponent<Enemy>().TakeDamage((float)0.5); });

        coldownTimer -= Time.deltaTime;
        if (coldownTimer <= 0 && enemies.Count < 30)
        {
            coldownTimer = cooldown;
            CreateObject();
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    private void CreateObject()
    {
        GameObject newObject = objectPool.GetObject(prefabs[Random.Range(0, prefabs.Count)], transform); //Instantiate(prefab, this.transform);
        enemies.Add(newObject);
        //Destroy(newObject, 2);
        //StartCoroutine(ReturnWithDelay());
        //objectPool.ReturnObject(newObject, 0.5f);
    }

    

}