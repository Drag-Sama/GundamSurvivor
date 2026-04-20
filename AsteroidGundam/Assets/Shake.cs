using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] AnimationCurve curve;
    
    public void ShakeCamera(float duration, float strength)
    {
        StartCoroutine(Shaking(duration, strength));
    }

    IEnumerator Shaking(float duration, float shakeStrength)
    {
        Vector3 startPosition = cameraHolder.transform.position;
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            cameraHolder.transform.position = startPosition + Random.insideUnitSphere * strenght * shakeStrength;
            yield return null;
        }
        cameraHolder.transform.position = startPosition;
    }
}
