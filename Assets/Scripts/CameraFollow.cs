using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    private void Update()
    {
        Vector3 playerPoition = Player.instance.transform.position;
        transform.position = new Vector3(playerPoition.x, transform.position.y, playerPoition.z);
    }
}
