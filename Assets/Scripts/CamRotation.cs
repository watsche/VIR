using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamRotation : MonoBehaviour
{
    Movement_Controller controls;
    Vector2 rotate;
    public float zAxis = 0;
    void Awake()
    {
        controls = new Movement_Controller();
        
        controls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;
    }
    void Update()
    {
        Vector3 r = new Vector3(rotate.y, 0, zAxis) * 100f * Time.deltaTime;
        transform.Rotate(r, Space.World);
    }
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
