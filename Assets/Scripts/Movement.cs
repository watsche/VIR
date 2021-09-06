    using System.Collections;  
    using System.Collections.Generic;  
    using UnityEngine;
    using UnityEngine.InputSystem;  
      
    public class Movement : MonoBehaviour  
    {  
         Movement_Controller controls;
        public Transform cam;
        Vector2 move;
        Vector2 rotate;
	    void Awake()
       {
            controls = new Movement_Controller();
            controls.Gameplay.Move.performed += ctx =>	move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

            controls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
            controls.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;

       }
       void  Update()
        {
            Vector3 camF = cam.forward;
            Vector3 camR = cam.right;

            camF.y = 0;
            camR.y = 0;
            camF = camF.normalized;
            camR = camR.normalized;

        //Vector3 m = new Vector3(move.x , 0, move.y) * Time.deltaTime;
        //transform.Translate(m, Space.World);
            Vector3 m = (camF*move.y + camR*move.x) * Time.deltaTime;
            transform.Translate(m, Space.World);
        
            Vector2 r = new Vector2(0, rotate.x) * 100f * Time.deltaTime;
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

