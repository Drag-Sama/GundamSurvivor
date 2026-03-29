using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float shakeDuration;
    [SerializeField] float shakeStrength;

    private void Start()
    {
        if (shakeDuration > 0)
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shake>().ShakeCamera(shakeDuration, shakeStrength);

        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
