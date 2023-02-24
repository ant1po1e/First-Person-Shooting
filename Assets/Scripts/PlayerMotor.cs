using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 PlayerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector3 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.y = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        PlayerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && PlayerVelocity.y < 0)
            PlayerVelocity.y = -2f;
        controller.Move(PlayerVelocity * Time.deltaTime);
        Debug.Log(PlayerVelocity.y);
    }
    
    public void Jump()
    {
        if(isGrounded)
        {
            PlayerVelocity.y = Mathf.Sqrt(jumpHeight * -3.8f * gravity);
        }
    }
}
