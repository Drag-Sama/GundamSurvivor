using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemie"))
        {
            collision.GetComponent<EnnemieHeal>().TakeDamage(100);
        }
    }
}
