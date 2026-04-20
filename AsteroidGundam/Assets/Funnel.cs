using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnel : MonoBehaviour
{
    Transform position;
    Transform funnelController;
    List<Transform> targets = new List<Transform>();
    [SerializeField] float speed;
    [SerializeField] int power;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firePoint;
    bool isAttacking = false;
    Vector2 nextPos;

    public void Init(Transform nvPosition, Transform nvFunnelController)
    {
        position = nvPosition;
        funnelController = nvFunnelController;
    }

    public void AddTarget(Transform nvTarget)
    {
        targets.Add(nvTarget);
    }

    void Fire()
    {
        var actualTarget = targets[0];
        GameObject bulletIns = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation, firePoint.transform);
        bulletIns.GetComponent<Bullet>().power = power;

        float randomAngle = Random.Range(0f, 2 * Mathf.PI - float.Epsilon);
        Vector2 pos = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)) * 4;
        nextPos = new Vector2(actualTarget.transform.position.x + pos.x, actualTarget.transform.position.y + pos.y);
        
    }

    IEnumerator FireDelay()
    {
        isAttacking = true;
        Fire();
        yield return new WaitForSeconds(0.3f);
        if(targets.Count > 0 && targets[0])
            StartCoroutine(FireDelay());
        else
            isAttacking = false;
    }

    void Update()
    {
        if (position && targets.Count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, position.position, speed * Time.deltaTime);
            transform.rotation = funnelController.rotation;
        }
        if(targets.Count > 0)
        {
            if (targets[0])
            {
                if (!isAttacking)
                {
                    StartCoroutine(FireDelay());
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * 2 * Time.deltaTime);
                    transform.up = targets[0].position - transform.position;
                }
            }
            else
            {
                targets.RemoveAt(0);
            }
            
        }   
    }
}
