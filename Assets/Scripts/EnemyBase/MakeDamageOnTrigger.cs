using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    public int DamageValue = 1;
    public void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(DamageValue);
            }
        }
    }
}
