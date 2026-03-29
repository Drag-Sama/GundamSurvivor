using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieHeal : MonoBehaviour
{
    [SerializeField] int maxHeal;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] bool haveMsMovement;
    [SerializeField] bool haveTourelle;
    public int heal;

    SpriteRenderer sp;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        heal = maxHeal;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>().AddEnemy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        heal -= damage;
        StartCoroutine(delayColor());

        if(heal <= 0)
        {
            if(explosionEffect != null)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                Instantiate(explosionEffect, transform.position, transform.rotation);
                StartCoroutine(delayDestroy(1.5f));
            }
            else //Au lieu de juste faire despawn la partie du vaisseau, on peut faire spawn une copie sans pv qui se detacherais du vaisseau et qui flotterais dans l'espace pendant un certain temps
            {
                StartCoroutine(delayDestroy(0));
            }
        }
    }

    IEnumerator delayColor()
    {
        sp.color = new Color(0.8f, 0.8f, 0.8f);
        yield return new WaitForSeconds(0.1f);
        sp.color = new Color(1, 1, 1);
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().power);
            collision.gameObject.GetComponent<Bullet>().onHit();
        }
    } */

    IEnumerator delayDestroy(float delay)
    {
        if (haveMsMovement)
        {
            GetComponent<EnemyMsMovement>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
        if (haveTourelle)
        {
            GetComponent<Tourelle>().enabled = false;
        }
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>().RemoveEnemy(this.gameObject);
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
