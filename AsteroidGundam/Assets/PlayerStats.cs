using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerHeal playerHeal;
    PlayerMovement playerMovement;

    //Actual MS Stats
    int maxHealth;
    float speed;
    float boostSpeed;

    //Actual Weapons Stats
    List<float> delay = new List<float>();
    List<int> power = new List<int>();
    List<int> magazineSize = new List<int>();
    List<float> reloadTime = new List<float>();

    private void Awake()
    {
        playerHeal = GetComponent<PlayerHeal>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    public void InitNewMS(MobileSuitClass ms)
    {
        maxHealth = ms.maxHealth;
        speed = ms.speed;
        boostSpeed = ms.boostSpeed;
    }

    public void InitNewWeapons(List<WeaponClass> weapons)
    {
        foreach (var weapon in weapons)
        {
            delay.Add(weapon.delay);
            power.Add(weapon.power);
            magazineSize.Add(weapon.magazineSize);
            reloadTime.Add(weapon.reloadTime);
        }
    }

    //MS Set/Update

    public void SetMaxHealth(int nvMaxHealth)
    {
        maxHealth = nvMaxHealth;
        playerHeal.Init(maxHealth);
    }

    public void SetSpeed(float nvSpeed)
    {
        speed = nvSpeed;
        playerMovement.Init(speed, boostSpeed);
    }

    public void SetBoostSpeed(float nvBoostSpeed)
    {
        boostSpeed = nvBoostSpeed;
        playerMovement.Init(speed, boostSpeed);
    }

    //Weapons
    //Get

    public float GetDelay(int weaponId)
    {
        return delay[weaponId];
    }

    public int GetPower(int weaponId)
    {
        return power[weaponId];
    }

    public int GetMagazineSize(int weaponId)
    {
        return magazineSize[weaponId];
    }

    public float GetReloadTime(int weaponId)
    {
        return reloadTime[weaponId];
    }

    //Set
    public void SetDelay(float nvDelay, int weaponId)
    {
        delay[weaponId] = nvDelay;
    }

    public void SetPower(int nvPower, int weaponId)
    {
        power[weaponId] = nvPower;
    }

    public void SetMagazineSize(int nvSize, int weaponId)
    {
        magazineSize[weaponId] = nvSize;
    }

    public void SetReloadTime(float nvTime, int weaponId)
    {
        reloadTime[weaponId] = nvTime;
    }


    public void GetUpgrade(UpgradeClass upgrade) //Prend une upgrade et met à jour les stats selon le type de l'upgrade
    {
        switch (upgrade.upgradeType)
        {
            case 0: //MaxHealth
                SetMaxHealth((int)upgrade.GetCalculatedValue(maxHealth));
                break;
            case 1: //Speed
                SetSpeed(upgrade.GetCalculatedValue(speed));
                break;
            case 2: //BoostSpeed
                SetBoostSpeed(upgrade.GetCalculatedValue(boostSpeed));
                break;
            case 3: //Delay
                SetDelay(upgrade.GetCalculatedValue(delay[upgrade.weaponId]), upgrade.weaponId);
                break;
            case 4: //Power
                SetPower((int)upgrade.GetCalculatedValue(power[upgrade.weaponId]), upgrade.weaponId);
                break;
            case 5: //MagazineSize
                SetMagazineSize((int)upgrade.GetCalculatedValue(magazineSize[upgrade.weaponId]), upgrade.weaponId);
                break;
            case 6: //ReloadTime
                SetReloadTime(upgrade.GetCalculatedValue(reloadTime[upgrade.weaponId]), upgrade.weaponId);
                break;

        }
    }
}
