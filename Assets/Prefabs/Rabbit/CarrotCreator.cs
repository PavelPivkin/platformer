using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCreator : MonoBehaviour
{
    public GameObject CarrotPrefab;
    public Transform Spawn;

    public void CreateCarrot() {
        Instantiate(CarrotPrefab, Spawn.position, Quaternion.identity);
    }
}
