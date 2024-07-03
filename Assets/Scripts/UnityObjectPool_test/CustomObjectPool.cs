using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CustomObjectPool
{
    //private ObjectPool<GameObject> pool;
    private Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

    public CustomObjectPool(GameObject prefab)
    {
        //pool = new ObjectPool<GameObject>();
    }

    //private GameObject CreateFromPool(string key, Transform parent)
    //{
    //    return GameObject.Instantiate(pool)
    //}

}
