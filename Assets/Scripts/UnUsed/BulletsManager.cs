using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    private void Awake()
    {
        SetupPool();
    }

    private void SetupPool()
    {
        ObjectPooler.SetupPool(bulletPrefab, 10, "Bullet");
    }
}
