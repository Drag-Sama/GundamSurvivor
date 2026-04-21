using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    Button button;
    public List<UpgradeClass> upgrades = new List<UpgradeClass>();

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClikc);
    }

    void TaskOnClikc()
    {
        var playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        foreach (var upgrade in upgrades)
        {
            playerStats.GetUpgrade(upgrade);
        }
        button.enabled = false;
        //TODO Faire une fonction dans le upgradeController qui nous remet dans le jeu
    }
}
