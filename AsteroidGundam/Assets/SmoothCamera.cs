using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    public float displacementMultiplier = 0.15f;
    float zPosition = -10;

    public void Init(GameObject player)
    {
        target = player.transform;
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cameraDisplacement = (mousePosition - target.position) * displacementMultiplier;

        Vector3 cameraPosition = target.position + cameraDisplacement;
        cameraPosition.z = zPosition;
        transform.position = cameraPosition;
    }
}
