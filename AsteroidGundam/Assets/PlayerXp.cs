using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    int xpNeeded = 10;
    int actualXp;
    int level;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LevelManager>();
    }

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
        levelManager.LevelUp();
    }
}
