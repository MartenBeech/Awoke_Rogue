using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitStat : MonoBehaviour
{
    public void DisplayStats(int tile)
    {
        if (tile == PlayerMovement.tilePos)
        {
            PlayerMovement.Player.GetComponentInChildren<Text>().text = "<color=green>" + PlayerStat.health + "/" + PlayerStat.healthMax + "</color>";
            PlayerMovement.Player.GetComponentInChildren<Text>().alignment = TextAnchor.LowerCenter;
            UI.HealthBar.GetComponentInChildren<Text>().text = PlayerStat.health + " / " + PlayerStat.healthMax;

            if (PlayerStat.health > 0)
            {
                UI.HealthBar.GetComponentInChildren<Image>().fillAmount = (float)PlayerStat.health / PlayerStat.healthMax;
            }
            else
            {
                UI.HealthBar.GetComponentInChildren<Image>().fillAmount = 0;
            }
            
        }
        else if (Enemy.occupied[tile])
        {
            GameObject.Find("Enemy" + tile).GetComponentInChildren<Text>().text = "<color=red>" + Enemy.enemies[tile].damage + "</color>" + "   " + "<color=green>" + Enemy.enemies[tile].health + "</color>";
            GameObject.Find("Enemy" + tile).GetComponentInChildren<Text>().alignment = TextAnchor.LowerCenter;
        }
    }

    public enum Units
    {
        DireWolf
    };

    public void SetStats(int tile, Units unit)
    {
        string title = unit.ToString();
        for (int i = 1; i < title.Length; i++)
        {
            if ((int)title[i] >= 65 && (int)title[i] <= 90) //Capital Letters
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
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;
        }
    }
}
