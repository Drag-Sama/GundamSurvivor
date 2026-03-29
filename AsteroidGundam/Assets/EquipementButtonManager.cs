using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EquipementButtonManager : MonoBehaviour
{
    [SerializeField] GameObject weaponPage;
    [SerializeField] GameObject weaponButton;
    [SerializeField] List<WeaponClass> weapons;

    [SerializeField] GameObject msPage;
    [SerializeField] GameObject msButton;
    [SerializeField] List<MobileSuitClass> mobilesSuits;

    private void Start()
    {
        Init();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var ins = GameObject.FindGameObjectWithTag("MainMenu");
        if(ins != null)
        {
            msPage = ins.GetComponent<EquipementReference>().msPage;
            weaponPage = ins.GetComponent<EquipementReference>().weaponPage;
            Init();
        }
    }

    public void Init()
    {
        int index = 0;
        foreach (var weapon in weapons)
        {
            Vector3 pos = new Vector3(300 + (250 * (index % 2)), 300 - (250 * (index / 2)), 0);
            InitWeaponButton(weapon, pos);
            index++;
        }

        index = 0;
        foreach (var ms in mobilesSuits)
        {
            Vector3 pos = new Vector3(300 + (250 * (index % 2)), 300 - (250 * (index / 2)), 0);
            InitMobileSuitButton(ms, pos);
            index++;
        }
    }

    void InitWeaponButton(WeaponClass weapon, Vector3 pos)
    {
        var buttonIns = Instantiate(weaponButton, transform.position, transform.rotation, weaponPage.transform);
        buttonIns.transform.localPosition = pos;
        buttonIns.transform.localScale = new Vector3(1, 1, 1);
        buttonIns.GetComponent<WeaponButton>().Init(weapon, GetComponent<Equipement>());
    }

    void InitMobileSuitButton(MobileSuitClass ms, Vector3 pos)
    {
        var buttonIns = Instantiate(msButton, transform.position, transform.rotation, msPage.transform); 
        buttonIns.transform.localPosition = pos;
        buttonIns.transform.localScale = new Vector3(1, 1, 1);
        buttonIns.GetComponent<MobileSuitButton>().Init(ms, GetComponent<Equipement>());
    }
}
