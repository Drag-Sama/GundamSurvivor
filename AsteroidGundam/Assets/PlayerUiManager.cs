using UnityEngine;
using UnityEngine.UI;

public class PlayerUiManager : MonoBehaviour
{
    [SerializeField] WeaponUiGenerator weaponUi;
    [SerializeField] HealthUi healthUi;
    [SerializeField] GameObject upgradeUi;

    public void Init(GameObject nvPlayer, Camera camera)
    {
        var canvas = GetComponent<Canvas>();
        canvas.worldCamera = camera;

        weaponUi.InitUi(nvPlayer);
        healthUi.InitUi(nvPlayer);
    }

    public void InitUpgradeUi()
    {
        upgradeUi.SetActive(true);
        upgradeUi.GetComponent<UpgradeController>().InitNewUpgrades(3);
    }

    public void DisabledUpgradeUi()
    {
        upgradeUi.SetActive(false);
    }
}
