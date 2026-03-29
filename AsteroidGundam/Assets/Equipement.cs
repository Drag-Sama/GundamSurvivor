using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Equipement : MonoBehaviour
{
    [SerializeField] EquipementDisplay equipementDisplay;

    [SerializeField] MobileSuitClass ms;
    [SerializeField] List<WeaponClass> weapons;
    int nbWeaponsMax = 2;

    //L'ordre des fonctions au démarrage c'est :
    //1 - Awake
    //2 - OnEnable
    //3 - Start
    private void Awake()
    {
        var nbIns = GameObject.FindGameObjectsWithTag("Equipement");
        if (nbIns.Length != 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(transform.gameObject);
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var ins = GameObject.FindGameObjectWithTag("MainMenu");
        if (ins != null)
        {
            equipementDisplay = ins.GetComponent<EquipementReference>().equipementDisplay;
            equipementDisplay.InitMs(ms);
            equipementDisplay.InitWeapons(weapons);
        }
            
    }

    public void SelectMobileSuit(MobileSuitClass selectedMs)
    {
        ms = selectedMs;
        equipementDisplay.InitMs(ms);
    }

    public void SelectWeapon(WeaponClass weapon)
    {
        if (isWeaponEquiped(weapon))
        {
            RemoveWeapon(weapon);
        }
        else
        {
            AddWeapons(weapon);
        }
    }

    public bool isWeaponEquiped(WeaponClass weapon)
    {
        var weaponIns = weapons.Find(w => w == weapon);
        return (weaponIns != null);
    }

    public void AddWeapons(WeaponClass nvWeapon)
    {
        if(CanHaveMoreWeapon())
            weapons.Add(nvWeapon);
        equipementDisplay.InitWeapons(weapons);
    }

    public void RemoveWeapon(WeaponClass weapon)
    {
        weapons.Remove(weapon);
        equipementDisplay.InitWeapons(weapons);
    }

    bool CanHaveMoreWeapon()
    {
        return weapons.Count < nbWeaponsMax;
    }

    public MobileSuitClass GetMs()
    {
        return ms;
    }

    public List<WeaponClass> GetWeapons()
    {
        return weapons;
    }
}
