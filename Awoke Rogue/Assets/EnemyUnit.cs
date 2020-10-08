using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnit : MonoBehaviour
{
    public int xPos;
    public int yPos;
    public int tilePos;

    public string title;
    public int health;
    public int range = 2;
    public int damage;
    public int cooldown = 3;
    public enum Type { Physical, Magical };

    public bool preparing;
    public int cantAttack;
    public int cantMove;

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
        AnimaText animaText = new AnimaText();
        animaText.ShowText(tile, "Prepare", Color.red);
        GameObject.Find("Enemy" + tile).GetComponentInChildren<Image>().color = Color.red;
    }

    public void AttackAction(int tile)
    {
        if (Enemy.enemies[tile].cantAttack == 0)
        {
            Enemy.enemies[tile].preparing = false;
            AnimaText animaText = new AnimaText();
            animaText.ShowText(tile, "Attack", Color.red);
            GameObject.Find("Enemy" + tile).GetComponentInChildren<Image>().color = Color.white;
        }
    }
}
