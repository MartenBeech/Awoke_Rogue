﻿using System.Collections;
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
        DireWolf, Sentinel, Cavalier, Guardian, Chaplain, Landsknecht, Seraph,
        Gargoyle, Golem, Djinn, Rakshasa, Apprentice, ArcaneEagle, Colossus,
        Ghost, EbonSpider, Vampire, Lich, Lamasu, GrimRider, BoneDragon
    };

    public List<Units> GetUnitLevels(int level)
    {
        List<Units> units = new List<Units>();
        if (level == 1)
        {
            units.Add(Units.DireWolf);
            units.Add(Units.Sentinel);
            units.Add(Units.Gargoyle);
            units.Add(Units.Golem);
            units.Add(Units.Ghost);
            units.Add(Units.EbonSpider);
        }
        else if (level == 2)
        {
            units.Add(Units.Cavalier);
            units.Add(Units.Guardian);
            units.Add(Units.Djinn);
            units.Add(Units.Rakshasa);
            units.Add(Units.Vampire);
            units.Add(Units.Lich);
        }
        else if (level == 3)
        {
            units.Add(Units.Chaplain);
            units.Add(Units.Landsknecht);
            units.Add(Units.Apprentice);
            units.Add(Units.ArcaneEagle);
            units.Add(Units.Lamasu);
            units.Add(Units.GrimRider);
        }
        else if (level == 4)
        {
            units.Add(Units.Seraph);
            units.Add(Units.Colossus);
            units.Add(Units.BoneDragon);
        }

        return units;
    }

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
        Enemy.enemies[tile].title = title;

        switch (unit)
        {
            // LEVEL 1
            case Units.DireWolf:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Sentinel:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Gargoyle:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Golem:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Ghost:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.EbonSpider:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            // LEVEL 2
            case Units.Cavalier:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Guardian:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Djinn:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Rakshasa:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Vampire:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Lich:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            // LEVEL 3
            case Units.Chaplain:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Landsknecht:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Apprentice:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.ArcaneEagle:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Lamasu:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.GrimRider:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            // LEVEL 4
            case Units.Seraph:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.Colossus:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;

            case Units.BoneDragon:
                Enemy.enemies[tile].health = 20;
                Enemy.enemies[tile].range = 1;
                Enemy.enemies[tile].damage = 4;
                Enemy.enemies[tile].cooldown = 1;
                Enemy.enemies[tile].type = EnemyUnit.Type.Melee;
                break;
        }
    }
}
