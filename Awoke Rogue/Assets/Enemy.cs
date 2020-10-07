using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    const int SIZE = Tile.SIZE;
    Rng rng = new Rng();
    public static bool enemyTurn = false;
    public static EnemyUnit[] enemies = new EnemyUnit[SIZE];
    public static bool[] occupied = new bool[SIZE];

    public enum Difficulty
    {
        Easy, Normal, Hard
    };

    public void SummonRandomEnemy(Difficulty difficulty)
    {
        int rnd;
        do
        {
            rnd = rng.Range(0, 1600);
        }
        while (Tile.type[rnd] != Tile.Type.DungeonFloor || !Tile.passable[rnd]);

        List<string> enemies = new List<string>();

        if (difficulty == Difficulty.Easy)
        {
            enemies.Add("Dire Wolf");
        }
        else if (difficulty == Difficulty.Normal)
        {
            enemies.Add("Dire Wolf");
        }
        else if (difficulty == Difficulty.Hard)
        {
            enemies.Add("Dire Wolf");
        }
        SummonEnemy(rnd, enemies[rng.Range(0, enemies.Count)]);
    }

    public void SummonEnemy(int tile, string title)
    {
        GameObject prefab = Resources.Load<GameObject>("Assets/Enemy");
        GameObject parent = GameObject.Find("Enemies");
        prefab = Instantiate(prefab, Tile.Tiles[tile].transform.position, Tile.Tiles[tile].transform.rotation, parent.transform);
        
        prefab.name = "Enemy" + tile.ToString();

        enemies[tile] = new EnemyUnit();
        occupied[tile] = true;
        prefab.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Enemies/" + title);
        MoveEnemy(prefab, tile, tile);
    }

    public void MoveEnemy(GameObject prefab, int from, int to)
    {
        enemies[to] = new EnemyUnit();

        enemies[to].tilePos = to;
        enemies[to].xPos = to % 40;
        enemies[to].yPos = to / 40;
           
        GameObject.Find("Enemy" + from.ToString()).name = "Enemy" + to.ToString();

        occupied[from] = false;
        Tile.passable[from] = true;
        Tile.passable[to] = false;
        occupied[to] = true;

        AnimaUnit animaUnit = new AnimaUnit();
        animaUnit.MoveUnit(prefab, from, to);
    }

    public void Destroy(int tile)
    {
        GameObject.Destroy(GameObject.Find("Enemy" + tile.ToString()));
        enemies[tile] = null;
        occupied[tile] = false;
        Tile.passable[tile] = true;
    }
}
