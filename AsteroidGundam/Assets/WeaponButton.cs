using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    Image image;
    Button button;
    WeaponClass weapon;
    Equipement equipementManager;

    [SerializeField] Image icon;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text powerText;
    [SerializeField] TMP_Text fireRateText;

    [SerializeField] Color baseColor;
    [SerializeField] Color selectedColor;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClikc);
        image = GetComponent<Image>();
        image.color = baseColor;
    }

    private void Update()
    {
        if (equipementManager)
        {
            if (equipementManager.isWeaponEquiped(weapon))
            {
                image.color = selectedColor;
            }
            else
                image.color = baseColor;
        }
    }

    public void Init(WeaponClass nvWeapon,Equipement nvEquipementManager)
    {
        weapon = nvWeapon;
        equipementManager = nvEquipementManager;

        icon.sprite = weapon.icon;
        nameText.text = weapon.weaponName;
        powerText.text = "Power : " + weapon.power.ToString();
        fireRateText.text = "Fire rate : " + (60 / weapon.delay).ToString() + " rounds/min";
    }

    void TaskOnClikc()
    {
        equipementManager.SelectWeapon(weapon);
    }
}
