using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;
    public AudioSource AddHealthSound;
    public UnityEvent EventOnTakeDamage;


    public HealthUI HealthUI;
    private bool _invulnerable;

    private void Start() {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damage)
    {
        if (_invulnerable == false)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Health = 0;

                Die();
            }

            _invulnerable = true;
            EventOnTakeDamage.Invoke();
            HealthUI.DisplayHealth(Health);
            Invoke("StopInvulnerable", 1f);
        }
    }

    public void AddHealth(int healthValue)
    {
        Health += healthValue;

        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
        }
        AddHealthSound.Play();
        HealthUI.DisplayHealth(Health);
    }

    public void Die()
    {
        Debug.Log("You lose");
    }

    private void StopInvulnerable() {
        _invulnerable = false;
    }
}
