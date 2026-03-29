using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MobileSuitButton : MonoBehaviour
{
    Button button;
    MobileSuitClass ms;
    Equipement equipementManager;

    [SerializeField] Image icon;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text speedText;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClikc);
    }

    public void Init(MobileSuitClass nvMS, Equipement nvEquipementManager)
    {
        ms = nvMS;
        equipementManager = nvEquipementManager;

        icon.sprite = ms.bodySprite;
        nameText.text = ms.nameMS;
        healthText.text = "Health : " + ms.maxHealth.ToString();
        speedText.text = "Speed : " + (ms.speed*4).ToString() + " m/s";
    }

    void TaskOnClikc()
    {
        equipementManager.SelectMobileSuit(ms);
    }
}
