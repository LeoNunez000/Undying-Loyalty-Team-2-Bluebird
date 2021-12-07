using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Movement : MonoBehaviour {
    [SerializeField] float groundedSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float inAirSpeed;
    [SerializeField] float fallSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] KeyCode runKey = KeyCode.LeftShift;
    [SerializeField] float jumpForce;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] float breakForce;
    [SerializeField] GroundCheck groundCheck;

    Rigidbody playerRigidBody;

    Vector3 movement = Vector3.zero;

    void Awake() {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        var input = Input.GetAxis("Horizontal");

        if(input == 0f) {
            HitTheBrakes();
        } else {
            Move(input);
        }


        if(Input.GetKeyDown(jumpKey)) {
            HandleJump();
        }
    }

    private void FixedUpdate() {
        if(playerRigidBody.velocity.y < 0f) {
            playerRigidBody.AddForce(Vector3.down * fallSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    void HandleJump() {
        if(groundCheck.IsGrounded) { Jump(); }
    }

    void Jump() {
        playerRigidBody.AddForce(Vector3.up * jumpForce);
    }

    void HitTheBrakes() {
        if(!groundCheck.IsGrounded && playerRigidBody.velocity.magnitude > 0f) {
            playerRigidBody.AddForce(-playerRigidBody.velocity * breakForce * Time.deltaTime);
        }
    }

    void Move(float input) {
        if(playerRigidBody.velocity.magnitude < maxSpeed) {
            playerRigidBody.AddForce(Vector3.forward * input * MoveSpeed() * Time.deltaTime);
        }
    }

    public float MoveSpeed() {
        float result = 0f;
        if(groundCheck.IsGrounded) {
            result = Input.GetKey(runKey) ? runSpeed : groundedSpeed;
        } else {
            result = inAirSpeed;
        }

        return result;
    }
}
