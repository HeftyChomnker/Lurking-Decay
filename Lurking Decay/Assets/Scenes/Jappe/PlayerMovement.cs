using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public int speed;
    public float gravity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(Vector3.forward * Time.deltaTime);
        }
        controller.Move(Vector3.down * gravity);
        Debug.Log(controller.isGrounded);
    }
}
