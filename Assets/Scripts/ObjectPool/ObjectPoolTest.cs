using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolTest : MonoBehaviour
{
    [SerializeField] private GameObject startPrefab;
    [SerializeField] private int poolSize;
    private Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
    private Dictionary<GameObject, GameObject> pooledObjectOrigins = new Dictionary<GameObject, GameObject>();

    public static ObjectPoolTest instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    //private void Start()
    //{
    //    InitializeNewPool(startPrefab);
    //}

    public GameObject GetObject(GameObject prefab, Transform target)
    {
        if (!poolDictionary.ContainsKey(prefab))
        {
            InitializeNewPool(prefab);
        }

        GameObject objToGet = poolDictionary[prefab].Dequeue();

        if (poolDictionary[prefab].Count == 0)
        {
            CreateNewObject(prefab);
            
        }

        objToGet.transform.position = target.position;
        //_objToGet.transform.rotation = target.rotation;
        
        objToGet.SetActive(true);

        //Debug.Log(_objToGet.GetComponent<EnemyStatsManager>().MaxHealth);

        return objToGet;
    }

    public void ReturnObject(GameObject objectToReturn)
    {
        //Debug.Log("return object");
        GameObject _originalPrefab = pooledObjectOrigins[objectToReturn];
        objectToReturn.SetActive(false);
        objectToReturn.transform.parent = transform;
        poolDictionary[_originalPrefab].Enqueue(objectToReturn);
    }
    public void ReturnObject(GameObject objectToReturn, float delay)
    {
        StartCoroutine(ReturnToPool(objectToReturn, delay));
        Debug.Log("return object with delay");
        //GameObject _originalPrefab = pooledObjectOrigins[objectToReturn];
        //objectToReturn.SetActive(false);
        //objectToReturn.transform.parent = transform;
        //poolDictionary[_originalPrefab].Enqueue(objectToReturn);
    }


    private void InitializeNewPool(GameObject prefab)
    {
        poolDictionary[prefab] = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject(prefab);
        }
    }

    private void CreateNewObject(GameObject prefab)
    {
        GameObject newObject = Instantiate(prefab, transform); 
        newObject.SetActive(false);
        poolDictionary[prefab].Enqueue(newObject);
        pooledObjectOrigins[newObject] = prefab;
    }

    private IEnumerator ReturnToPool(GameObject objectToReturn, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject _originalPrefab = pooledObjectOrigins[objectToReturn];
        objectToReturn.SetActive(false);
        objectToReturn.transform.parent = transform;
        poolDictionary[_originalPrefab].Enqueue(objectToReturn);
    }
}
