using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] GameObject upgradeButtonPrefab;
    List<GameObject> upgradeButtons = new List<GameObject>();

    public void InitNewUpgrades(int nbUpgrade)
    {
        for(int i=0; i<nbUpgrade; i++)
        {
            var buttonIns = Instantiate(upgradeButtonPrefab);
            upgradeButtons[i] = buttonIns;

            UpgradeClass upgrade = new UpgradeClass();
            upgrade.Init();
            upgrade.SetRandomUpgrade(Random.Range(-1, 2));

            buttonIns.GetComponent<UpgradeButton>().upgrades.Add(upgrade);
        }
    }
}
