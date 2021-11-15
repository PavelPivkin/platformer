using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    public int DamageValue = 1;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            PlayerHealth playerHealth = collision.rigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(DamageValue);
            }
        }
    }
}
