using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEditor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private Rigidbody rigibody;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 750;

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.PlayerMovement.Enable();
    }

    private void OnMovement(InputValue _inputValue)
    {
        Debug.Log("moving");
        Vector3 movementDirection = new Vector3(_inputValue.Get<Vector2>().x, 0, _inputValue.Get<Vector2>().y);
        rigibody.velocity = movementDirection * speed;
        if (rigibody.velocity != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            rigibody.rotation = Quaternion.RotateTowards(rigibody.rotation, rotation, rotationSpeed);
        }
    }

    private void OnValidate()
    {
        rigibody ??= GetComponent<Rigidbody>();
        rigibody.interpolation = RigidbodyInterpolation.Interpolate;
        rigibody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    //private void FixedUpdate()
    //{
    //    Vector2 _moveDirection = playerControls.PlayerMovement.Movement.ReadValue<Vector2>();
    //    transform.position += new Vector3(_moveDirection.x, 0, _moveDirection.y) * speed;
    //}

    //private void Move()
    //{
    //    Vector2 direction = playerControls.PlayerMovement.Movement.ReadValue<Vector2>();
    //    Debug.Log($"moving in direction {direction}");
    //    transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime * speed;
    //}

}
