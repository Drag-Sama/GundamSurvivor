using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    int xpNeeded = 10;
    int actualXp;
    int level;

    public void AddXp(int xp)
    {
        actualXp += xp;
        if(actualXp >= xpNeeded)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        actualXp =- xpNeeded;
        xpNeeded = (int)(xpNeeded * 1.2f);
        level++;
    }
}
