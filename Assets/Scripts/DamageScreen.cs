using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    public Image DamageImage;
    public void StartEffect(float effectDuration = 1f) {
        StartCoroutine(ShowEffect());
    }

    public IEnumerator ShowEffect(float effectDuration = 1f)
    {
        DamageImage.enabled = true;

        for (float t = effectDuration; t >= 0f; t -= Time.deltaTime)
        {
            DamageImage.color = new Color(1, 0, 0, t);

            yield return null;
        }

        DamageImage.enabled = false;
    }
}
