using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public void OnCollisionEnter(Collision collision) {
        if(collision.rigidbody && collision.rigidbody.GetComponent<Bullet>()) {
            EnemyHealth.TakeDamage(1);
        }
    }
}
