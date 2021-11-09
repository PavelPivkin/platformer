using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 4f;
    public float RotationSpeed = 3f;

    private Transform _playerTransform;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;

        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
}
