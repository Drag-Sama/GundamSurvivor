using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUiGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> anchorPoints; //Point ou les WeaponUi seront selon si c'est l'arme principale ou une arme secondaire;
    [SerializeField] GameObject WeaponUi; //Objet qui affichera les infos de l'arme
    weapon playerWeapons; //Script qui gère les armes du joueurs

    public void InitUi(GameObject nvPlayer)
    {
        playerWeapons = nvPlayer.GetComponentInChildren<weapon>();
        for (int i = 0; i < playerWeapons.weapons.Count; i++)
        {
            GameObject weaponIns = Instantiate(WeaponUi, anchorPoints[i].transform);
            weaponIns.GetComponent<WeaponUI>().setWeapon(playerWeapons.weapons[i]);
        }
    }
}
