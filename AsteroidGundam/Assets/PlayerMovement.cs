using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveX;
    float moveY;
    float speed; //Vitesse actuel
    float boostSpeed; //Vitesse lors du boost
    float baseSpeed; //Vitesse de base

    bool boosting;
    bool canBoost = true;
    TrailRenderer tr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    public void Init(float nvSpeed, float nvBoostSpeed)
    {
        baseSpeed = nvSpeed;
        boostSpeed = nvBoostSpeed;
        speed = baseSpeed;
    }
    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        //Visé de la souris
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = direction;

        if (Input.GetKeyDown(KeyCode.Space) && canBoost)
        {
            if (boosting == false)
            {
                boost();
            }
            boosting = true;
            speed = boostSpeed;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            boosting = false;
            speed = baseSpeed;
        }
    }

    void boost()
    {
        rb.angularDrag = 10;
        StartCoroutine(boostDelay());
    }

    IEnumerator boostDelay()
    {
        canBoost = false;
        yield return new WaitForSeconds(0.05f);
        speed = boostSpeed * 4;
        rb.angularDrag = 0.7f;
        yield return new WaitForSeconds(0.2f);
        if (boosting)
        {
            speed = boostSpeed;
        }
        else
        {
            speed = baseSpeed;
        }
        canBoost = true;
    }

    private void FixedUpdate()
    {
       
        rb.AddForce(new Vector2(moveX, moveY).normalized * speed);
        updateTrailLength();
    }

    public float actualSpeed() //Renvoie la vitesse du joueur
    {
        return Mathf.Abs(rb.velocity.x )+ Mathf.Abs(rb.velocity.y);
    }

    void updateTrailLength() //Calcul la longueur de Trail selon la vitesse actuel du joueur
    {
        float actSpeed = actualSpeed();
        tr.time = actSpeed / 5;
    }

    
}
