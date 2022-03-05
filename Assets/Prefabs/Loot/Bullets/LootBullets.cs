using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    public int NumberOfBullets = 30;
    public int GunIndex;
    public void OnTriggerEnter(Collider other)
    {
        PlayerArmory playerHealth = other.attachedRigidbody.GetComponent<PlayerArmory>();
        if (playerHealth) {
            playerHealth.AddBullets(GunIndex, NumberOfBullets);

            Destroy(gameObject);
        }
    }

}
