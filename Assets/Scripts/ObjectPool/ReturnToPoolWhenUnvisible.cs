using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPoolWhenUnvisible : MonoBehaviour
{
    public float TimeBeforeReturn = 0;
    private void Update()
    {
        if (!IsVisible())
        {
            StartCoroutine(ReturnToPool());
        }
        else StopCoroutine(ReturnToPool());
    }
    private bool IsVisible()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(transform.position) < 0)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(TimeBeforeReturn);
        ObjectPoolTest.instance.ReturnObject(this.gameObject);
    }
}
