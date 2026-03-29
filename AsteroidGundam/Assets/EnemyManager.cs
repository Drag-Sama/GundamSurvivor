using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemys;
    public int nbEnemyDestroyed = 0;

    public void AddEnemy(GameObject nvEnemy)
    {
        enemys.Add(nvEnemy);
    }

    public void RemoveEnemy(GameObject actEnemy)
    {
        nbEnemyDestroyed++;
        enemys.Remove(actEnemy);
    }

    public void PlayerDied()
    {
        foreach(GameObject enemy in enemys)
        {
            enemy.SetActive(false);
        }
    }
}
