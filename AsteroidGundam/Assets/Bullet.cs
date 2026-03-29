using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int power;
    [SerializeField] bool isEnnemie;
    //OnHit
    [SerializeField] bool destroyOnHit;
    [SerializeField] int soundOnHit;
    [SerializeField] float delay;
    [SerializeField] GameObject effectOnHit;

    SoundManager sm;

    private void Start()
    {
        sm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isEnnemie)
        {
            collision.GetComponent<PlayerHeal>().TakeDamage(power);
            onHit();
        }
        else if(collision.CompareTag("Ennemie") && !isEnnemie)
        {
            collision.GetComponent<EnnemieHeal>().TakeDamage(power);
            onHit();
        }
    }

    public void onHit()
    {
        if(soundOnHit != -1)
            sm.playSound(soundOnHit);

        if (destroyOnHit)
            StartCoroutine(delayDestroy());
        if (effectOnHit != null)
            Instantiate(effectOnHit, transform.position, transform.rotation);
    }

    IEnumerator delayDestroy()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
