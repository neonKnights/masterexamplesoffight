using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private Transform head;


    private Vector3 movementDirection;
    private Vector3 headRotation;

    private void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime * speed);
    }

    private void OnEnable()
    {
        movementDirection = Vector3.zero;
        headRotation = Vector3.zero;
        head.localRotation = Quaternion.Euler(headRotation);
    }
    private void OnShoot(InputValue inputValue)
    {
        Debug.Log("OnFire");
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 value = inputValue.Get<Vector2>();
        if(value.x != 0)
        {
            transform.Rotate(0, value.x, 0);
        }
        if(value.y != 0)
        {
            headRotation.x += -value.y;
            headRotation.x = Mathf.Clamp(headRotation.x, -90, 90);
            head.localRotation = Quaternion.Euler(headRotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 value = inputValue.Get<Vector2>();
        movementDirection = new Vector3(value.x, 0, value.y);
    }

}
