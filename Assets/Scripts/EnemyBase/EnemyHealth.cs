using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health;
    public UnityEvent EventOnTakeDamage;
    public void TakeDamage(int damage) {
        Health -= damage;

        EventOnTakeDamage.Invoke();

        if (Health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }
}
