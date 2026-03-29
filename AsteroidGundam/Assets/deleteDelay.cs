using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteDelay : MonoBehaviour
{
    [SerializeField] float delay;

    private void Awake()
    {
        StartCoroutine(delayTime());
    }

    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
