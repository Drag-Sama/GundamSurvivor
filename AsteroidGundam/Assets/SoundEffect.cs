using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] int id;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>().playSound(id);
    }
}
