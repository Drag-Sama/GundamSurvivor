using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject soundObject;

    [SerializeField] List<AudioClip> soundList;

    public void playSound(int clip)
    {
        GameObject soundIns = Instantiate(soundObject);
        soundIns.GetComponent<AudioSource>().clip = soundList[clip];
        soundIns.GetComponent<AudioSource>().pitch = Random.Range(0.9f,1.1f);
        soundIns.GetComponent<AudioSource>().Play();
    }
}
