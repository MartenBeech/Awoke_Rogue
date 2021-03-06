﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : MonoBehaviour
{
    public int xPos;
    public int yPos;
    public int tilePos;

    public string title;
    public int health = 20;
    public int range = 1;
    public int damage = 4;
    public int cooldown = 1;
    public enum Type { Melee, Ranged, Magical };
    public Type type = Type.Melee;

    public bool preparing;
    public int cantAttack;
    public int cantMove;

    public bool boss;
    public bool keyKeeper;
    public bool artifactKeeper;

    public void MoveAction(int tile)
    {
        if (Enemy.occupied[tile])
        {
            string movement = "";
            if (Enemy.enemies[tile].yPos > PlayerMovement.yPos)
            {
                if (Tile.passable[tile - 40])
                {
                    movement += "N";
                }
            }
            if (Enemy.enemies[tile].yPos < PlayerMovement.yPos)
            {
                if (Tile.passable[tile + 40])
                {
                    movement += "S";
                }
            }
            if (Enemy.enemies[tile].xPos > PlayerMovement.xPos)
            {
                if (Tile.passable[tile - 1])
                {
                    movement += "W";
                }
            }
            if (Enemy.enemies[tile].xPos < PlayerMovement.xPos)
            {
                if (Tile.passable[tile + 1])
                {
                    movement += "E";
                }
            }

            if (movement.Length > 0)
            {
                Rng rng = new Rng();
                char randomMovement = movement[rng.Range(0, movement.Length)];

                Enemy enemy = new Enemy();
                if (randomMovement == 'N')
                {
                    enemy.MoveEnemy(GameObject.Find("Enemy" + tile), tile, tile - 40);
                }
                else if (randomMovement == 'S')
                {
                    enemy.MoveEnemy(GameObject.Find("Enemy" + tile), tile, tile + 40);
                }
                else if (randomMovement == 'W')
                {
                    enemy.MoveEnemy(GameObject.Find("Enemy" + tile), tile, tile - 1);
                }
                else if (randomMovement == 'E')
                {
                    enemy.MoveEnemy(GameObject.Find("Enemy" + tile), tile, tile + 1);
                }
            }
        }
    }

    public void PrepareAction(int tile)
    {
        Enemy.enemies[tile].preparing = true;
        GameObject.Find("Enemy" + tile).GetComponentInChildren<Image>().color = Color.red;
    }

    public void AttackAction(int tile)
    {
        if (Enemy.enemies[tile].cantAttack == 0)
        {
            Enemy.enemies[tile].preparing = false;
            DamagePlayer(Enemy.enemies[tile].damage, tile, Enemy.enemies[tile].type);
            GameObject.Find("Enemy" + tile).GetComponentInChildren<Image>().color = Color.white;
        }
    }

    public void DamagePlayer(int damage, int tile, Type type)
    {
        Rng rng = new Rng();
        damage = rng.Range(Mathf.FloorToInt(damage * 0.5f), Mathf.FloorToInt(damage * 1.5f) + 1);
        PlayerStat playerStat = new PlayerStat();
        playerStat.TakeDamage(damage);
        UnitStat unitStat = new UnitStat();
        unitStat.DisplayStats(tile);
    }
}
