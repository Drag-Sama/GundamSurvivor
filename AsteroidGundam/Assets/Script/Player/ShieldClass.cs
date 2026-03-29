using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "MobileSuit / Create new Shield")]
public class ShieldClass : ScriptableObject
{
    public Vector2 posInUse; //Position lorsqu'il est utilisé
    public Quaternion rotationInUse;
    public Sprite spriteInUse;

    public Vector2 posNotInUse; //Position lorsqu'il est rangé
    public Quaternion rotationNotInUse;
    public Sprite spriteNotInUse;

}
