using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "MobileSuit / Create new Upgrade")]
public class UpgradeClass : ScriptableObject
{
    //0-maxHealth
    //1-speed
    //2-boostSpeed
    //--------------
    //3-delay
    //4-power
    //5-magazineSize
    //6-reloadTime

    public int upgradeType;
    public List<float> upgradeValues = new List<float>();


    //0-common 60%
    //1-rare 25%
    //2-epic 10%
    //3-legendary 5%
    public int rarity;

    public int weaponId = -1;

    public void Init()
    {
        upgradeValues.Add(10);
        upgradeValues.Add(0.05f);
        upgradeValues.Add(0.05f);

        upgradeValues.Add(0.03f);
        upgradeValues.Add(5);
        upgradeValues.Add(4);
        upgradeValues.Add(0.05f);

        var rand = Random.Range(0, 100);

        switch (rand)
        {
            case var expression when rand < 60: //Common
                rarity = 0;
                break;
            case var expression when rand < 85: //Rare
                rarity = 1;
                break;
            case var expression when rand < 95: //Epic
                rarity = 2;
                break;
            default:  //Legendary
                rarity = 3;
                break;
        }

    }

    public void SetRandomUpgrade(int type)
    {
        if(type == -1)
        {
            upgradeType = Random.Range(0, 2);
        }
        else
        {
            upgradeType = Random.Range(3, 6);
            weaponId = type;
        }
    }

    public float GetCalculatedValue(float baseValue) //Renvoie la valeur de la stats après l'amélioration
    {
        if(upgradeValues[upgradeType] < 1)
        {
            return baseValue * (1 + (upgradeValues[upgradeType] * (1+rarity))); //TODO faudrait prendre la valeur de base et la multiplier
        }
        else
        {
            return baseValue + upgradeValues[upgradeType] * (1 + rarity);
        }
    }
}
