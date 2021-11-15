using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Vector3 Velocity;
    public float MaxRotationSpeed;
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddRelativeForce(Velocity, ForceMode.VelocityChange);

        float angularVelocity = Random.Range(-MaxRotationSpeed, MaxRotationSpeed);
        rigidbody.angularVelocity = new Vector3(angularVelocity, angularVelocity, angularVelocity);
    }
}
