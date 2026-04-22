using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] GameObject upgradeButtonPrefab;
    List<GameObject> upgradeButtons = new List<GameObject>();
    [SerializeField] List<GameObject> buttonPoints;

    weapon playerWeapon;
    public void InitNewUpgrades(int nbUpgrade)
    {
        if (!playerWeapon) //Si playerWeapon n'a pas été trouvé
        {
            playerWeapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<weapon>();
        }


        upgradeButtons = new List<GameObject>();
        for(int i=0; i<nbUpgrade; i++)
        {
            var buttonIns = Instantiate(upgradeButtonPrefab, buttonPoints[i].transform.position, buttonPoints[i].transform.rotation, buttonPoints[i].transform);
            upgradeButtons.Add(buttonIns);

            UpgradeClass upgrade = new UpgradeClass();
            upgrade.Init();
            upgrade.SetRandomUpgrade(Random.Range(-1, playerWeapon.weapons.Count)); //Entre -1 et le nombre d'armes du joueur 
            
            
            buttonIns.GetComponent<UpgradeButton>().Init(new List<UpgradeClass> { upgrade });
        }
    }
}
