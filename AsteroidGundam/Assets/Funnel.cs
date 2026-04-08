using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnel : MonoBehaviour
{
    Transform position;
    Transform target;
    [SerializeField] float speed;
    bool isAttacking = false;
    Vector2 nextPos;

    public void Init(Transform nvTarget)
    {
        position = nvTarget;  
    }

    public void Attack(Transform nvTarget)
    {
        target = nvTarget;
    }

    void Fire()
    {
         float randomAngle = Random.Range(0f, 2 * Mathf.PI - float.Epsilon);
        Vector2 pos = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)) * 4;
        Debug.Log("TargetPos" + target.transform.position);
        Debug.Log("PosRandom" + pos);
        nextPos = new Vector2(target.transform.position.x + pos.x, target.transform.position.y + pos.y);
        transform.right = target.position - transform.position; 
    }

    IEnumerator FireDelay()
    {
        isAttacking = true;
        Fire();
        yield return new WaitForSeconds(0.3f);
        if(target)
            StartCoroutine(FireDelay());
        else
            isAttacking = false;
    }

    void Update()
    {
        if (position && !target)
        {
            transform.position = Vector3.MoveTowards(transform.position, position.position, speed * Time.deltaTime);
        }
        if (target && !isAttacking)
        { //A chaque tire tu changes de position sur un cercle
           StartCoroutine(FireDelay());
        }
        if(target && isAttacking)
        {//TODO ajouter la vitesse de la cible en plus de speed * 2 * Time.delaTime
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * 2 * Time.deltaTime);
        }

            
    }
}
