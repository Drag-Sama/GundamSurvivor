using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] GameObject firePoint;
    [SerializeField] SpriteRenderer weaponSprite;
    [SerializeField] WeaponClass weaponAct;
    public List<WeaponClass> weapons;
    public List<int> magazines = new List<int>();
    public int idWeaponEquiped = 0;

    bool isFire = false;
    bool fireDelay = false;
    public bool attacking = false;
    PlayerMain pm;

    GameObject gameManager;
    Shake cameraShake;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        pm = GetComponentInParent<PlayerMain>();
        weaponAct = weapons[idWeaponEquiped];
        weaponSprite.sprite = weapons[idWeaponEquiped].sprite;
        firePoint.transform.localPosition = weapons[idWeaponEquiped].firePointPos;
    }

    private void Start()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shake>();
    }

    private void Update()
    {
        if (!attacking)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                isFire = true;
                StartCoroutine(Fire());
            }
            if (Input.GetButtonUp("Fire1"))
            {
                isFire = false;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                SwitchWeapon();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                pm.meleeAnimation();
            }
        }
        

        
    }

    void SwitchWeapon()
    {
        idWeaponEquiped = (idWeaponEquiped + 1) % weapons.Count;
        InitWeapon();
    }

    public void InitWeapon()
    {
        weaponAct = weapons[idWeaponEquiped];
        weaponSprite.sprite = weapons[idWeaponEquiped].sprite;
        firePoint.transform.localPosition = weapons[idWeaponEquiped].firePointPos;
        pm.updateArmSprite(weapons[idWeaponEquiped]);
    }


    IEnumerator Fire()
    {
        if (!fireDelay && !attacking && magazines[idWeaponEquiped] > 0)
        {
            
            GameObject bulletIns = Instantiate(weaponAct.bullet, firePoint.transform.position, this.transform.rotation);

            cameraShake.ShakeCamera(0.1f, 0.4f);
            gameManager.GetComponent<SoundManager>().playSound(weaponAct.soundEffect);
            magazines[idWeaponEquiped]--;
            fireDelay = true;

            bulletIns.GetComponent<Rigidbody2D>().AddForce(this.transform.up * weaponAct.bulletSpeed);
            bulletIns.GetComponent<Bullet>().power = weaponAct.power;

            if (magazines[idWeaponEquiped] == 0)
            {
                StartCoroutine(Reload(weapons[idWeaponEquiped].reloadTime, idWeaponEquiped));
            }

            yield return new WaitForSeconds(weaponAct.delay);
            fireDelay = false;
            if (isFire && weaponAct.isAutomatic)
            {
                StartCoroutine(Fire());
            }

            

        }
        
    }

    IEnumerator Reload(float reloadTime, int weaponId)
    {
        yield return new WaitForSeconds(reloadTime);
        magazines[weaponId] = weapons[weaponId].magazineSize;
    }
}
