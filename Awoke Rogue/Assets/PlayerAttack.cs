﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public const int SIZE = 6;
    public static GameObject[] Abilities = new GameObject[SIZE];
    public static int abilitySelected = SIZE;
    public static Artifact.Title[] title = new Artifact.Title[SIZE];
    public static string[] description = new string[SIZE];
    public static bool[] occupied = new bool[SIZE];
    public static int[] range = new int[SIZE];
    public static int[] level = new int[SIZE];
    public static int[] cooldown = new int[SIZE];
    public static int[] cooldownMax = new int[SIZE];
    public static int[] powerMin = new int[SIZE];
    public static int[] powerMax = new int[SIZE];
    public static int[] powerSpecial = new int[SIZE];
    public enum Target { Self, Enemy, Ground};
    public static Target[] target = new Target[SIZE];

    private void Start()
    {
        for (int i = 0; i < SIZE; i++)
        {
            Abilities[i] = GameObject.Find("Ability (" + i + ")");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
            AbilityClicked(0);
        else if (Input.GetKeyDown("2"))
            AbilityClicked(1);
        else if (Input.GetKeyDown("3"))
            AbilityClicked(2);
        else if (Input.GetKeyDown("4"))
            AbilityClicked(3);
        else if (Input.GetKeyDown("5"))
            AbilityClicked(4);
        else if (Input.GetKeyDown("6"))
            AbilityClicked(5);
    }

    public void UseAbility(int tile)
    {
        if (abilitySelected < SIZE)
        {
            int i = abilitySelected;
            Distance distance = new Distance();
            if (cooldown[i] == 0 && distance.GetDistanceToPlayer(tile) <= range[i])
            {
                AbilityEffect ability = new AbilityEffect();
                ability.UseAbility(i, tile);

                cooldown[i] = cooldownMax[i] + 1;
                DisplayAbility(i);

                UI ui = new UI();
                ui.EndTurn();

                if (PlayerStat.rage > 0)
                {
                    PlayerStat playerStat = new PlayerStat();
                    playerStat.GainRage(1);
                }
            }
        }
    }

    public void DamageEnemy(int damage, int tile)
    {
        Enemy.enemies[tile].health -= damage;
        UnitStat unitStat = new UnitStat();
        unitStat.DisplayStats(tile);
        AnimaText animaText = new AnimaText();
        animaText.ShowText(tile, damage.ToString(), Color.red);

        if (Enemy.enemies[tile].health <= 0)
        {
            Enemy enemy = new Enemy();
            enemy.Destroy(tile);
        }
    }

    public void DisplayAbility(int i)
    {
        if (cooldown[i] > 0)
        {
            Abilities[i].GetComponentInChildren<Text>().text = cooldown[i].ToString();
            Abilities[i].GetComponentInChildren<Button>().enabled = false;
            Abilities[i].GetComponentInChildren<Image>().color = Color.gray;
        }
        else
        {
            Abilities[i].GetComponentInChildren<Text>().text = null;
            Abilities[i].GetComponentInChildren<Button>().enabled = true;
            Abilities[i].GetComponentInChildren<Image>().color = Color.white;
        }
    }

    public void AbilityClicked(int i)
    {
        //if (Abilities[i].GetComponentInChildren<Button>().enabled)
        {
            if (abilitySelected == i)
            {
                Abilities[i].GetComponentInChildren<Outline>().enabled = false; ;
                UI.Description.GetComponentInChildren<Text>().text = null;
                abilitySelected = SIZE;
            }

            else
            {
                abilitySelected = i;

                for (int j = 0; j < SIZE; j++)
                {
                    Abilities[j].GetComponentInChildren<Outline>().enabled = false;
                }
                Abilities[i].GetComponentInChildren<Outline>().enabled = true;
                Artifact artifact = new Artifact();
                UI.Description.GetComponentInChildren<Text>().text = artifact.GetDescription(title[i], i);
            }
        }
    }
}
