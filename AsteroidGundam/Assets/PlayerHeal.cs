using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    int maxHealth;
    int actualHealth;
    bool isInvincible = false;

    public void Init(int nvHealth)
    {
        maxHealth = nvHealth;
        actualHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            actualHealth -= damage;
            
            if (actualHealth <= 0)
                Destroy();
            else
                StartCoroutine(DelayInvincible());
        }
        
    }

    public float GetAcutalHealth()
    {
        return (float)actualHealth / (float)maxHealth;
    }

    IEnumerator DelayInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1.5f);
        isInvincible = false;
    }

    void Destroy()
    {
        isInvincible = true;
        GetComponent<PlayerMovement>().enabled = false;
        actualHealth = 0;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>().GameOver();
    }
}
