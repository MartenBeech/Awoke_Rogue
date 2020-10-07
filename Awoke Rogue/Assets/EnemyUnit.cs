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

    public void TakeTurn(int tile)
    {
        if (Enemy.occupied[tile])
        {
            string movement = "";
            if (Enemy.enemies[tile].yPos > PlayerMovement.yPos && Tile.passable[tile - 40])
            {
                movement += "N";
            }
            if (Enemy.enemies[tile].yPos < PlayerMovement.yPos && Tile.passable[tile + 40])
            {
                movement += "S";
            }
            if (Enemy.enemies[tile].xPos > PlayerMovement.xPos && Tile.passable[tile - 1])
            {
                movement += "W";
            }
            if (Enemy.enemies[tile].xPos < PlayerMovement.xPos && Tile.passable[tile + 1])
            {
                movement += "E";
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
}
