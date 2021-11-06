using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Transform ColliderTransform;
    public Transform PointerTransform;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;

    public float MaxSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftControl) || Grounded == false) {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 20);
        } else {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 20);
        }

        TurnToAim();
    }

    void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (Grounded == false) {
            speedMultiplier = 0.2f;
        }

        if (Rigidbody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0) {
            speedMultiplier = 0;
        }

        if (Rigidbody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0) {
            speedMultiplier = 0;
        }

        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (Grounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(Vector3.up, collision.contacts[i].normal);

            if (angle < 45f)
            {
                Grounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }

    private void TurnToAim() {
        float lookDirection = Vector3.Dot(PointerTransform.forward, Vector3.right);

        if (lookDirection < 0) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(1, 0, 1)), Time.deltaTime * 10f);
        } else {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(-1, 0, 1)), Time.deltaTime * 10f);
        }
    }
}
