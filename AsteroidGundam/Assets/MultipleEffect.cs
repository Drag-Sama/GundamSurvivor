using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleEffect : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] int nbEffect;
    [SerializeField] float duration;
    [SerializeField] GameObject effect;

    private void Start()
    {
        spawnMultipleEffect();
    }

    void spawnMultipleEffect()
    {
        float avgDelay = duration / nbEffect;
        for (int i = 0; i < nbEffect; i++)
        {
            StartCoroutine(spawnOne(avgDelay + Random.Range(-0.5f, 0.5f), i));
        }
    }

    Vector3 getRandomPosition() //Renvoie une position random dans le cercle de rayon radius
    {
        Vector2 randomPos = Random.insideUnitCircle * radius;
        Vector3 position = new Vector3(transform.position.x + randomPos.x, transform.position.y + randomPos.y, transform.position.z);
        return position;
    }

    IEnumerator spawnOne(float delay, int nbEffectSpawned)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(effect, getRandomPosition(), transform.rotation);
        if (nbEffectSpawned >= nbEffect - 1)
        {
            Destroy(this.gameObject); // s'auto détruit après avoir fais spawn tous les effets
        }
    }
}
