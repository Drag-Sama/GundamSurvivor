using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class EquipementDisplay : MonoBehaviour
{
    MobileSuitClass ms;
    [SerializeField] Image msIcon;
    [SerializeField] TMP_Text msNameText;

    List<WeaponClass> weapons = new List<WeaponClass>();
    List<GameObject> weaponsIns = new List<GameObject>();
    [SerializeField] GameObject weaponDisplay;
    
    public void InitMs(MobileSuitClass selectedMs)
    {
        ms = selectedMs;
        msIcon.sprite = ms.bodySprite;
        msNameText.text = ms.nameMS;
    }

    public void InitWeapons(List<WeaponClass> selectedWeapons)
    {
        ResetWeaponsDisplay();
        weapons = selectedWeapons;

        for (int i = 0; i < weapons.Count; i++)
        {
            GameObject ins = Instantiate(weaponDisplay);
            ins.transform.SetParent(this.transform);
            ins.transform.localPosition = new Vector3(0, -150 * i, 0);
            ins.transform.localScale = new Vector3(1, 1, 1);
            ins.GetComponent<WeaponDisplay>().InitWeapon(weapons[i]);
            weaponsIns.Add(ins);
        }
    }

    void ResetWeaponsDisplay()
    {
        for (int i = weaponsIns.Count - 1; i >= 0; i--)
        {
            Destroy(weaponsIns[i].gameObject);
        }
        weaponsIns.Clear();
    }
}
