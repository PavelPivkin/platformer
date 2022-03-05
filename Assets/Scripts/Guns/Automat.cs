using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    public int NumberOfBullets;
    public Text BulletText;
    public PlayerArmory playerArmory;

    public override void Shot() {
        base.Shot();

        NumberOfBullets -= 1;
        BulletText.text = NumberOfBullets.ToString();

        if (NumberOfBullets == 0) {
            playerArmory.TakeGunByIndex(0);
        }
    }


    public override void Activate()
    {
        base.Activate();
        BulletText.enabled = true;
        UpdateBulletText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        BulletText.enabled = false;
    }

    private void UpdateBulletText() {
        BulletText.text = NumberOfBullets.ToString();
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);

        NumberOfBullets += numberOfBullets;

        UpdateBulletText();

        playerArmory.TakeGunByIndex(1);
    }
}
