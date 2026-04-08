using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpShard : MonoBehaviour
{
    bool followPlayer = false;
    Transform player;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            followPlayer = true;
        }
    }

    void Update()
    {
        if (followPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, 20 * Time.deltaTime);
        }
    }
}
