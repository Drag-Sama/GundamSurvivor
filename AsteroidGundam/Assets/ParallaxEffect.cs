using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    Transform player;
    [SerializeField] GameObject backgroundStars;

    [Range(0,1)]
    [SerializeField] float parallaxScale;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
        Parallax();
    }

    void Parallax()
    {
        backgroundStars.transform.position = new Vector3(-transform.position.x * parallaxScale, -transform.position.y * parallaxScale,backgroundStars.transform.position.z);
    }

    void FollowPlayer()
    {
        Vector3 pos = new Vector3(player.position.x/2, player.position.y/2,transform.position.z);
        transform.position = pos;
    }
}
