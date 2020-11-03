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

    public void SummonNormalEnemies(int amount)
    {
        List<UnitStat.Units> enemyList = new List<UnitStat.Units>();
        UnitStat unitStat = new UnitStat();
        enemyList = unitStat.GetUnitLevels(1);
        int keyCarrier = rng.Range(0, amount);

        for (int i = 0; i < amount; i++)
        {
            int rnd;
            do
            {
                rnd = rng.Range(0, 1600);
            }
            while (Tile.type[rnd] != Tile.Type.DungeonFloor || !Tile.passable[rnd] || occupied[rnd]);

            SummonEnemy(rnd, enemyList[rng.Range(0, enemyList.Count)]);
            if (i == keyCarrier)
            {
                enemies[rnd].keyCarrier = true;
            }
        }
    }

    public void SummonTreasureEnemies(int amount, List<int> tiles)
    {
        List<UnitStat.Units> enemyList = new List<UnitStat.Units>();
        UnitStat unitStat = new UnitStat();
        enemyList = unitStat.GetUnitLevels(2);

        for (int i = 0; i < amount; i++)
        {
            int rnd = rng.Range(0, tiles.Count);
            SummonEnemy(tiles[rnd], enemyList[rng.Range(0, enemyList.Count)]);
            tiles.RemoveAt(rnd);
        }
    }

    public void SummonBoss()
    {
        List<UnitStat.Units> enemyList = new List<UnitStat.Units>();
        UnitStat unitStat = new UnitStat();
        enemyList = unitStat.GetUnitLevels(3);

        for (int i = 0; i < Tile.SIZE; i++)
        {
            if (Tile.type[i] == Tile.Type.End)
            {
                SummonEnemy(i, enemyList[rng.Range(0, enemyList.Count)]);
                enemies[i].boss = true;
                break;
            }
        }
    }

    public void SummonEnemy(int tile, UnitStat.Units unit)
    {
        enemies[tile] = new EnemyUnit();
        enemies[tile].tilePos = tile;
        enemies[tile].xPos = tile % 40;
        enemies[tile].yPos = tile / 40;

        UnitStat unitStat = new UnitStat();
        unitStat.SetStats(tile, unit);

        GameObject prefab = Resources.Load<GameObject>("Assets/Enemy");
        GameObject parent = GameObject.Find("Enemies");
        prefab = Instantiate(prefab, Tile.Tiles[tile].transform.position, new Quaternion(0,0,0,0), parent.transform);
        
        prefab.name = "Enemy" + tile.ToString();

        occupied[tile] = true;
        unitStat.DisplayStats(tile);
        prefab.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Enemies/" + enemies[tile].title);
        MoveEnemy(prefab, tile, tile);
    }

    public void MoveEnemy(GameObject prefab, int from, int to)
    {
        if (to != from)
        {
            enemies[to] = new EnemyUnit();

            enemies[to].tilePos = to;
            enemies[to].xPos = to % 40;
            enemies[to].yPos = to / 40;

            enemies[to].title = enemies[from].title;
            enemies[to].health = enemies[from].health;
            enemies[to].range = enemies[from].range;
            enemies[to].damage = enemies[from].damage;
            enemies[to].cooldown = enemies[from].cooldown;

            enemies[to].preparing = enemies[from].preparing;
            enemies[to].cantAttack = enemies[from].cantAttack;
            enemies[to].cantMove = enemies[from].cantMove;

            enemies[to].boss = enemies[from].boss;
            enemies[to].keyCarrier = enemies[from].keyCarrier;


            GameObject.Find("Enemy" + from.ToString()).name = "Enemy" + to.ToString();

            occupied[from] = false;
            Tile.passable[from] = true;
            Tile.passable[to] = false;
            occupied[to] = true;
            enemies[from] = null;
        }

        AnimaUnit animaUnit = new AnimaUnit();
        animaUnit.MoveUnit(prefab, from, to);
    }

    public void Destroy(int tile)
    {
        if (enemies[tile].keyCarrier)
        {
            PlayerStat.keyObtained = true;
            AnimaText text = new AnimaText();
            text.ShowText(tile, "Gate Key obtained", Color.cyan);
        }
        if (enemies[tile].boss)
        {
            PlayerStat.bossKilled = true;
            AnimaText text = new AnimaText();
            text.ShowText(tile, "Staircase opened", Color.cyan);
        }
        GameObject.Destroy(GameObject.Find("Enemy" + tile.ToString()));
        enemies[tile] = null;
        occupied[tile] = false;
        Tile.passable[tile] = true;
    }
}
