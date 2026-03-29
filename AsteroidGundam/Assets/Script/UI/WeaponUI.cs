using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public WeaponClass actWeapon;
    [SerializeField] TMP_Text title;
    [SerializeField] Image icon;

    public void setWeapon(WeaponClass nvWeapon)
    {
        actWeapon = nvWeapon;
        title.text = actWeapon.name;
        icon.sprite = actWeapon.icon;
    }
}
