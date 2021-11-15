using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIcon;
    public List<GameObject> HealthIcons = new List<GameObject>();
    public void Setup(int maxHealth) {
        for (int i = 0; i < maxHealth; i++) {
            GameObject newIcon = Instantiate(HealthIcon, transform);
            HealthIcons.Add(newIcon);
        }
    }

    public void DisplayHealth(int health) {
        for (int i = 0; i < HealthIcons.Count; i++) {
            HealthIcons[i].SetActive(i < health);
        }
    }
}
