using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelController : MonoBehaviour
{
    [SerializeField] List<GameObject> funnelPoints;
    [SerializeField] GameObject funnelPrefab;
    List<GameObject> funnels = new List<GameObject>();
    GameObject target = null;

    void Start(){
        foreach (var point in funnelPoints)
        {
            GameObject funnelIns = Instantiate(funnelPrefab, point.transform.position, point.transform.rotation);
            funnelIns.GetComponent<Funnel>().Init(point.transform);
            funnels.Add(funnelIns);
        }
    }



    void Attack()
    {
        foreach(var funnel in funnels)
        {
            funnel.GetComponent<Funnel>().Attack(target.transform);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemie") && !target)
        {
            target = collision.gameObject;
            Attack();
        }
    }
}
