using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    public Animator Animator;
    public float Period = 3f;
    public string TriggerName = "Attack";

    private float _timer;

    void Update() {
        _timer += Time.deltaTime;

        if (_timer >= Period) {
            _timer = 0;

            Animator.SetTrigger(TriggerName);
        }
    }

}
