using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public float gravity;
    public int mouseSensitivity;

    CharacterController controller;
    float horizontalInput;
    float verticalInput;
    float mouseX;
    float mouseY;

    private void Start() { controller = GetComponent<CharacterController>(); }

    private void Update()
    {
        // player movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(movement * speed * Time.deltaTime);

        // adding gravity
        controller.Move(Vector3.down * gravity);

        // player camera
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(mouseY, 0f, 0f);
    }
}
