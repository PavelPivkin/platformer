using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Vector3 LeftEuler;
    public Vector3 RightEuler;
    public float RotationSpeed = 5f;

    private Transform _playerTransform;
    private Vector3 _targetEuler;

    void Start() {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void Update() {
        if (_playerTransform.position.x < transform.position.x) {
            _targetEuler = LeftEuler;
        } else {
            _targetEuler = RightEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }
}
