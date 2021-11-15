using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;
    void Start()
    {
        Destroy(gameObject, 4.0f);
    }

    public void OnCollisionEnter(Collision collision) {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody.GetComponent<EnemyHealth>()) {
            Instantiate(EffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
