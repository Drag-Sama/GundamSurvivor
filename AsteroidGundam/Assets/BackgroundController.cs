using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Vector2 startPos;
    public float lenght;
    public GameObject cam;
    public float paralaxEffect;

    void Start()
    {
        startPos = new Vector2(transform.position.x , transform.position.y);
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        Vector2 distance = new Vector2(cam.transform.position.x * paralaxEffect, cam.transform.position.y * paralaxEffect);
        Vector2 movement = new Vector2(cam.transform.position.x * (1 - paralaxEffect), cam.transform.position.y * (1 - paralaxEffect));

        transform.position = new Vector3(startPos.x + distance.x, startPos.y + distance.y, transform.position.z);

        if(movement.x > startPos.x + lenght)
        {
            startPos.x += lenght;
        }
        else if(movement.x < startPos.x - lenght)
        {
            startPos.x -= lenght;
        }
        else if(movement.y < startPos.y - lenght)
        {
            startPos.y -= lenght;
        }
        else if(movement.y > startPos.y + lenght)
        {
            startPos.y += lenght;
        }
    }
}
