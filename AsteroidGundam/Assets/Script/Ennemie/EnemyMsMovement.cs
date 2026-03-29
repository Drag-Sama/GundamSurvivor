using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMsMovement : MonoBehaviour
{
    GameObject target;
    Rigidbody2D rb;
    float moveX;
    float moveY;
    float speed = 10;

    [SerializeField] GameObject projectilDetection;
    [SerializeField] GameObject playerDetection;
    [SerializeField] GameObject dodgePoint;
    [SerializeField] float dodgeDelayTime;
    bool canDodge = true;
    bool dodging = false;
    bool bulletInRange = false;
    bool playerInRange;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator dodge()
    {
        dodging = true;
        canDodge = false;
        yield return new WaitForSeconds(0.15f);
        dodging = false;
        yield return new WaitForSeconds(dodgeDelayTime - 0.15f);
        canDodge = true;
    }

    void updateDetection()
    {
        bulletInRange = projectilDetection.GetComponent<objectDetection>().isIn;
        if(!playerInRange)
            playerInRange = playerDetection.GetComponent<objectDetection>().isIn;
    }

    void updateReaction()
    {
        if(bulletInRange && canDodge)
        {
            StartCoroutine(dodge());
        }
        if (playerInRange)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            transform.up = direction;
        }
    }

    private void Update()
    {
        updateDetection();
        updateReaction();
    }

    private void FixedUpdate() //TODO Recuperer la vie et si vie <= 0 on arrete de bouger et met rb.velocity à 0 pour qu'il arrete de bouger completement
    {
        if(dodging)
            transform.position = Vector3.MoveTowards(transform.position, dodgePoint.transform.position, speed * Time.deltaTime);
        if (playerInRange)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance > 6)
            {
                rb.AddForce(transform.up * speed);
            }
            else if(distance < 3)
            {
                rb.AddForce(-transform.up * (speed/2));
            }
        }
    }



}
