using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    const int SIZE = 50;
    Rng rng = new Rng();
    public static bool enemyTurn = false;
    public static GameObject[] Enemies = new GameObject[SIZE];
    public static EnemyUnit[] enemies = new EnemyUnit[SIZE];
    public static bool[] occupied = new bool[SIZE];

    private void Start()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i] = GameObject.Find("Enemy (" + i + ")");
            enemies[i] = new EnemyUnit();
        }
    }

    public void SummonRandomEnemy(string title)
    {
        int rnd;
        do
        {
            rnd = rng.Range(0, 1600);
        }
        while (Tile.type[rnd] != "Terrain" || !Tile.passable[rnd]);
        SummonEnemy(rnd, title);
    }

    public void SummonEnemy(int tile, string title)
    {
        int i = GetUnoccupied();
        if (i < SIZE)
        {
            Enemies[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Enemies/" + title);
            MoveEnemy(i, tile, tile);
            occupied[i] = true;
        }
    }

    public void MoveEnemy(int i, int from, int to)
    {
        enemies[i].tilePos = to;
        enemies[i].xPos = to % 40;
        enemies[i].yPos = to / 40;

        Enemies[i].GetComponentInChildren<AnimaUnit>().startPoint = Tile.Tiles[from];
        Enemies[i].GetComponentInChildren<AnimaUnit>().endPoint = Tile.Tiles[to];
        Enemies[i].GetComponentInChildren<AnimaUnit>().counter = 0.19f;

        Tile.passable[from] = true;
        Tile.passable[to] = false;
    }

    public int GetUnoccupied()
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (!occupied[i])
                return i;
        }
        return 20;
    }
}
