using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public ShieldClass shield;
    SoundManager sm;

    private void Start()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (!collision.GetComponent<Bullet>().ignoreShield)
            {
                sm.playSound(3);
                Destroy(collision.gameObject);
            }
            
        }
    }
}
