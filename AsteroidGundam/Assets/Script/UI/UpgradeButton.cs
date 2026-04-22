using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    Button button;
    [SerializeField] TMP_Text titleUpgrade;
    public List<UpgradeClass> upgrades = new List<UpgradeClass>();

    List<Color> rarityColors = new List<Color> {Color.white, Color.green, Color.magenta, Color.yellow };
    List<string> upgradeName = new List<string> { "Max health", "Speed", "Boost speed", "Fire rate", "Power", "Magazine size", "Reload time"};

    //0-maxHealth
    //1-speed
    //2-boostSpeed
    //--------------
    //3-delay
    //4-power
    //5-magazineSize
    //6-reloadTime

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClikc);
    }

    public void Init(List<UpgradeClass> nvUpgrades)
    {
        upgrades = nvUpgrades;
        titleUpgrade.text = upgradeName[upgrades[0].upgradeType] + " " + upgrades[0].upgradeValues[upgrades[0].upgradeType] * ( 1 + upgrades[0].rarity);
        titleUpgrade.color = rarityColors[upgrades[0].rarity];
    }

    void TaskOnClikc()
    {
        var playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        foreach (var upgrade in upgrades) //Applique les upgrades sur le joueur
        {
            playerStats.GetUpgrade(upgrade);
        }
        button.enabled = false;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>().UpgradeSelected(); //Relance le jeu
    }
}
