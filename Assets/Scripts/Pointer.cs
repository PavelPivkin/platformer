using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera PlayerCamera;

    void LateUpdate()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        Plane plane = new Plane(Vector3.forward, Vector3.zero);

        float distance = 0;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        Aim.transform.position = point;

        Vector3 toAim = Aim.position - transform.position;

        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
