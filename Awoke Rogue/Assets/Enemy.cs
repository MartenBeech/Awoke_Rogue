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

    public void SummonRandomEnemy(int difficulty)
    {
        int rnd;
        do
        {
            rnd = rng.Range(0, 1600);
        }
        while (Tile.type[rnd] != Tile.Type.DungeonFloor || !Tile.passable[rnd]);

        List<string> enemies = new List<string>();

        if (difficulty == 0)
        {
            enemies.Add("Dire Wolf");
        }
        else if (difficulty == 1)
        {
            enemies.Add("Dire Wolf");
        }
        else if (difficulty == 2)
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
        AnimaUnit animaUnit = new AnimaUnit();
        animaUnit.MoveUnit(prefab, tile, tile);

        prefab.name = "Enemy (" + tile.ToString() + ")";

        enemies[tile] = new EnemyUnit();
        occupied[tile] = true;
        prefab.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Enemies/" + title);
        MoveEnemy(tile, tile);
    }

    public void MoveEnemy(int from, int to)
    {
        enemies[to].tilePos = to;
        enemies[to].xPos = to % 40;
        enemies[to].yPos = to / 40;
        enemies[from] = null;

        GameObject.Find("Enemy (" + from.ToString() + ")").name = "Enemy (" + to.ToString() + ")";

        Tile.passable[from] = true;
        Tile.passable[to] = false;
        occupied[from] = false;
        occupied[to] = true;
    }

    public void Destroy(int tile)
    {
        GameObject.Destroy(GameObject.Find("Enemy (" + tile.ToString() + ")"));
    }
}
