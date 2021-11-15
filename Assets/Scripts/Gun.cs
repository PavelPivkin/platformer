using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed = 10.0f;
    public float ShotPeriod = 0.2f;
    public AudioSource ShotSound;
    public GameObject Flash;

    private float _timer = 0;
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > ShotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;

                GameObject bullet = Instantiate(BulletPrefab, Spawn.position, Quaternion.identity);

                bullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;

                ShotSound.Play();

                Flash.SetActive(true);

                Invoke("HideFlash", 0.12f);
            }
        }
    }

    public void HideFlash() {
        Flash.SetActive(false);
    }
}
