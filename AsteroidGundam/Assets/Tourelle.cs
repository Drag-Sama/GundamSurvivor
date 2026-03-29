using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourelle : MonoBehaviour
{
    [SerializeField] int power;
    [SerializeField] float delay;
    [SerializeField] float bulletSpeed;
    [SerializeField] bool canRafale;
    [SerializeField] int nbFireByRafale;
    [SerializeField] List<GameObject> firePoint;
    [SerializeField] List<Animator> fireAnim;
    [SerializeField] int nbCanon;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject range;
    [SerializeField] float rotationSpeed;

    [SerializeField] int soundEffect;

    GameObject target;
    GameObject gameManager;
    bool fireDelay;
    public bool targetAtRange;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Update()
    {
        targetAtRange = range.GetComponent<objectDetection>().isIn;
        if (targetAtRange)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            //transform.up = direction * rotationSpeed * Time.deltaTime;
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            angle *= -1;
 
            //if (direction.y < 0) angle = 180 - angle;
            //if (direction.x < 0) angle = 360 + angle;
            
            var rads = angle * Mathf.Deg2Rad;
            float testAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, angle,ref rotationSpeed, 0.1f);
            //transform.up = rotationSpeed * Time.deltaTime * new Vector2(Mathf.Cos(rads), Mathf.Sin(rads));
            transform.rotation = Quaternion.Euler(0, 0, testAngle);
            if (!fireDelay)
            {
                if (!canRafale)
                    StartCoroutine(Fire(0));
                else
                    StartCoroutine(Rafale(0, 0 - (int)Random.Range(-0.5f * nbFireByRafale, 0.5f *nbFireByRafale)));
            }
            
        }
        
    }

    void FireOne(int i)
    {
        GameObject bulletIns = Instantiate(bullet, firePoint[i % nbCanon].transform.position, this.transform.rotation);
        fireAnim[i % nbCanon].SetTrigger("Fire");
        gameManager.GetComponent<SoundManager>().playSound(soundEffect);
        bulletIns.GetComponent<Rigidbody2D>().AddForce(this.transform.up * bulletSpeed);
        bulletIns.GetComponent<Bullet>().power = power;
    }

    IEnumerator Fire(int i)
    {
        if (!fireDelay)
        {
            fireDelay = true;
            FireOne(i);
            yield return new WaitForSeconds(delay);
            fireDelay = false;
            if (targetAtRange)
            {
                StartCoroutine(Fire(i +1));
            }
        }
    }

    IEnumerator Rafale(int i, int nbFire)
    {
        if (nbFire < nbFireByRafale)
        {
            fireDelay = true;
            FireOne(i);
            if(nbFire < nbFireByRafale - 1)
                yield return new WaitForSeconds(delay / 5);
            else
                yield return new WaitForSeconds(Random.Range(delay* 0.8f, delay*1.5f));
            StartCoroutine(Rafale(i + 1, nbFire + 1));
        }
        else
            fireDelay = false;
    }
}
