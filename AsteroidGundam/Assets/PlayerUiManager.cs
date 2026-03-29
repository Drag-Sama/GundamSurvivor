using UnityEngine;
using UnityEngine.UI;

public class PlayerUiManager : MonoBehaviour
{
    [SerializeField] WeaponUiGenerator weaponUi;
    [SerializeField] HealthUi healthUi;

    public void Init(GameObject nvPlayer, Camera camera)
    {
        var canvas = GetComponent<Canvas>();
        canvas.worldCamera = camera;

        weaponUi.InitUi(nvPlayer);
        healthUi.InitUi(nvPlayer);
    }
}
