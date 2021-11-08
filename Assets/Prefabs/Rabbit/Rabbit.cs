using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public Animator Animator;
    public float AttackPeriod = 3f;

    private float _timer;

    void Update() {
        _timer += Time.deltaTime;

        if (_timer >= AttackPeriod) {
            _timer = 0;

            Animator.SetTrigger("Attack");
        }
    }

}
