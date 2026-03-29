using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0,100)] [SerializeField] float radius;
    [Range(1,200)] [SerializeField] float delayMin;
    [Range(1, 200)] [SerializeField] float delayMax;
    [SerializeField] GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(Delay());
    }

    void Spawn()
    {
        float randomAngle = Random.Range(0f, 2 * Mathf.PI - float.Epsilon);
        Vector2 pos = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)) * Random.Range(0,radius);
        Instantiate(enemyPrefab,pos, transform.rotation);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
        Spawn();
        StartCoroutine(Delay());
    }
}
