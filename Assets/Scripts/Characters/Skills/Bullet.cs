using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float attack;
    [SerializeField] private float lifeTime;
    [SerializeField] private float speed;
    [SerializeField] private bool isOwnedByPlayer;
    private float timeCasted;
    private Vector3 direction;
    //public float Attack { private get { return Attack * attackMultiplier; } set {  Attack = value; } }

    public void SetStats(float attack, bool isOwnedByPlayer, Vector3 direction)
    {
        this.attack = attack;
        this.isOwnedByPlayer = isOwnedByPlayer;
        this.direction = direction;
        //Debug.Log("sats seted, owned by player = " + isOwnedByPlayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        StatsManager _statsManager = null;
        if (other.CompareTag("Player") ^ isOwnedByPlayer) //
        {
            //Debug.Log($"trigger enter, object name: {other.name}");
            other.TryGetComponent(out _statsManager);
            _statsManager?.TakeDamage(attack);
            //this.gameObject.SetActive(false);
            //ObjectPoolTest.instance.ReturnObject(this.gameObject);
            ReturnToPool();
        }
            
        //return to pool
    }

    private void OnEnable()
    {
        //ObjectPoolTest.instance.ReturnObject(this.gameObject, lifeTime);
        //Invoke(nameof(ReturnToPool), lifeTime);
        //return to pool // invoke
        timeCasted = Time.time;
    }

    private void ReturnToPool()
    {
        ObjectPoolTest.instance.ReturnObject(this.gameObject);
    }

    private void Update()
    {
        //Debug.Log($"{gameObject.name} deriction is {deriction}");
        transform.Translate(direction * speed * Time.deltaTime);
        if (Time.time >= timeCasted + lifeTime)
        {
            ReturnToPool();
        }
        //transform.position = Vector3.MoveTowards(transform.position, deriction, 0.1f);
        //transform.localPosition += new Vector3(transform.forward.x, transform.position.y, transform.forward.z)  * speed * Time.deltaTime;
        //this.transform.localPosition += Vector3.forward * 0.1f; // * speed; //.Translate(destination * speed);  //Vector3.MoveTowards(transform.position, transform.forward, speed);
    }
}
