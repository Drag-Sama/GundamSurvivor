using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    [SerializeField] GameObject reactor;
    float speed = 0.2f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(reactor != null)
            rb.AddForce(new Vector2(-1,0) * speed);
    }
}
