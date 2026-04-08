using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [SerializeField] MobileSuitClass ms;

    [SerializeField] GameObject arm;
    [SerializeField] GameObject meleeHitBox;

    [SerializeField] GameObject shield;
    GameObject shieldIns;
    [SerializeField] SpriteRenderer weaponSprite;

    SpriteRenderer sp;
    Rigidbody2D rb;


    private void Start()
    {
        sp = arm.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetNewMS(MobileSuitClass selectedMs)
    {
        ms = selectedMs;
        InitMs();
    }

    void InitMs()
    {
        GetComponent<PlayerMovement>().Init(ms.speed, ms.boostSpeed);
        GetComponent<PlayerHeal>().Init(ms.maxHealth);

        if (ms.shield != null)
        {
            shieldIns = Instantiate(shield, ms.shield.posNotInUse, ms.shield.rotationNotInUse, this.transform);
        }

        GetComponent<SpriteRenderer>().sprite = ms.bodySprite;
        updateArmSprite(arm.GetComponent<weapon>().weapons[arm.GetComponent<weapon>().idWeaponEquiped]);

        
    }



    public void InitNewWeapons(List<WeaponClass> weapons)
    {
        arm.GetComponent<weapon>().weapons = weapons;
        arm.GetComponent<weapon>().InitWeapon();
    }

    public void updateArmSprite(WeaponClass weapon)
    {
        if (weapon.isTwoHanded)
        {
            arm.GetComponent<SpriteRenderer>().sprite = ms.armTwoHandedSprite;
            if (ms.shield != null)
            {
                shieldIns.transform.localPosition = ms.shield.posNotInUse;
                shieldIns.transform.localRotation = ms.shield.rotationNotInUse;
                shieldIns.GetComponent<SpriteRenderer>().sprite = ms.shield.spriteNotInUse;
            }

        }
        else
        {
            arm.GetComponent<SpriteRenderer>().sprite = ms.armOneHandedSprite;
            if (ms.shield != null)
            {
                shieldIns.transform.localPosition = ms.shield.posInUse;
                shieldIns.transform.localRotation = ms.shield.rotationInUse;
                shieldIns.GetComponent<SpriteRenderer>().sprite = ms.shield.spriteInUse;
            }
                
        }
    }

    public void meleeAnimation()
    {
        arm.GetComponent<weapon>().attacking = true;
        weaponSprite.enabled = false;
        meleeHitBox.SetActive(true);
        StartCoroutine(melee(0));
    }

    IEnumerator melee(int actualFrame)
    {
        if(actualFrame < ms.meleeSprites.Count)
        {
            
            sp.sprite = ms.meleeSprites[actualFrame];
            if (actualFrame < 2)
            {
                yield return new WaitForSeconds(0.12f);
                 rb.AddForce(transform.up.normalized * 200);
            }
                
            else
            {
                yield return new WaitForSeconds(0.06f);
                 rb.AddForce(transform.up.normalized * 100);
            }
                yield return new WaitForSeconds(0.06f);
            StartCoroutine(melee(actualFrame+=1));
        }
        else
        {
            meleeHitBox.SetActive(false);
            yield return new WaitForSeconds(0.02f);
            weaponSprite.enabled = true;
            updateArmSprite(arm.GetComponent<weapon>().weapons[arm.GetComponent<weapon>().idWeaponEquiped]);
            yield return new WaitForSeconds(0.05f);
            arm.GetComponent<weapon>().attacking = false;
        }
        
    }
}
