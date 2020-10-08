﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStat : MonoBehaviour
{
    public enum Units
    {
        DireWolf
    };
    public void SetStats(int tile, Units unit)
    {
        string title = unit.ToString();
        for (int i = 1; i < title.Length; i++)
        {
            if ((int)title[i] >= 65 && (int)title[i] <= 90) //Capital Letter
            {
                title = title.Insert(i, " ");
                i++;
            }
        }
        switch(unit)
        {
            case Units.DireWolf:
                Enemy.enemies[tile].title = "Dire Wolf";
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 3;
                Enemy.enemies[tile].cooldown = 1;
                break;
        }
    }

    public void DisplayStats(int tile)
    {
        if (tile == PlayerMovement.tilePos)
        {
            PlayerMovement.Player.GetComponentInChildren<Text>().text = "<color=green>" + PlayerStat.health + "/" + PlayerStat.healthMax + "</color>";
            PlayerMovement.Player.GetComponentInChildren<Text>().alignment = TextAnchor.LowerCenter;
        }
        else if (Enemy.occupied[tile])
        {
            GameObject.Find("Enemy" + tile).GetComponentInChildren<Text>().text = "<color=red>" + Enemy.enemies[tile].damage + "</color>" + "   " + "<color=green>" + Enemy.enemies[tile].health + "</color>";
            GameObject.Find("Enemy" + tile).GetComponentInChildren<Text>().alignment = TextAnchor.LowerCenter;
        }
    }
}