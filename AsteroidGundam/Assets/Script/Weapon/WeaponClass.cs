using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName ="MobileSuit / Create new Weapon")]
public class WeaponClass : ScriptableObject
{
    public bool isAutomatic;
    public bool isTwoHanded;
    public float delay;
    public int power;
    public GameObject bullet;
    public float bulletSpeed;
    public int soundEffect;
    public Vector2 firePointPos;

    public string weaponName;
    public Sprite sprite;
    public Sprite icon;
}
