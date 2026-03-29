using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLine : MonoBehaviour
{
    ParticleSystem ps;
    GameObject player;
    float actualSpeed;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        actualSpeed = player.GetComponent<PlayerMovement>().actualSpeed();
        var emission = ps.emission;
        emission.rateOverTime = actualSpeed * 1.5f;

        var shape = ps.shape;
        shape.radius = 37 - actualSpeed / 6;
    }
}
