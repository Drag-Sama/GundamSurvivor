using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MobileSuit", menuName = "MobileSuit / Create new Mobile Suit")]
public class MobileSuitClass : ScriptableObject
{
    public string nameMS;

    public int maxHealth;
    public float speed;
    public float boostSpeed;

    public ShieldClass shield;

    public Sprite bodySprite;
    public Sprite armTwoHandedSprite;
    public Sprite armOneHandedSprite;

    public List<Sprite> meleeSprites;
}
