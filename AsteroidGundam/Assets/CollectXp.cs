using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectXp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerXp>().AddXp(5);
            Destroy(transform.parent.gameObject);
        }
    }
}
