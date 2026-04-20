using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public WeaponClass actWeapon;
    [SerializeField] TMP_Text title;
    [SerializeField] Image icon;
    [SerializeField] TMP_Text magazine;
    weapon playerWeapon;
    int idWeapon;

    public void setWeapon(WeaponClass nvWeapon, weapon nvPlayerWeapon, int nvIdWeapon)
    {
        actWeapon = nvWeapon;
        title.text = actWeapon.name;
        icon.sprite = actWeapon.icon;
        playerWeapon = nvPlayerWeapon;
        idWeapon = nvIdWeapon;
    }

    private void Update()
    {
        if(playerWeapon.magazines.Count > idWeapon)
            magazine.text = playerWeapon.magazines[idWeapon].ToString() + "/" + actWeapon.magazineSize;
    }
}
