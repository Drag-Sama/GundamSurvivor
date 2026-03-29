using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    WeaponClass wp;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text nameText;

    public void InitWeapon(WeaponClass selectedWp)
    {
        wp = selectedWp;
        icon.sprite = wp.icon;
        nameText.text = wp.weaponName;
    }
}
