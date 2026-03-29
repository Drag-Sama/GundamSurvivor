using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    Slider bar;
    PlayerHeal playerHeal;
    float health;

    public void InitUi(GameObject nvPlayer)
    {
        bar = GetComponent<Slider>();
        playerHeal = nvPlayer.GetComponent<PlayerHeal>();
    }

    private void Update()
    {
        if(playerHeal != null)
        {
            var healthAct = playerHeal.GetAcutalHealth();
            if(health != healthAct)
            {
                health = playerHeal.GetAcutalHealth();
                bar.value = health;
            }
            
        }
            
    }
}
