using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    const int SIZE = 1600;
    public static GameObject[] Tiles = new GameObject[SIZE];

    public static string[] type = new string[SIZE];
    public static bool[] passable = new bool[SIZE];

    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Tiles[j + (40 * i)] = GameObject.Find("TilesHorizontal (" + i + ")/Tile (" + j + ")");
            }
        }
    }

    public void AddWall(int tile)
    {
        Tile.type[tile] = "Wall";
        Tile.Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Walls/Wall");
        Tile.passable[tile] = false;
    }

    public void AddTerrain(int tile)
    {
        Tile.type[tile] = "Terrain";
        Tile.Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Terrains/Terrain");
        Tile.passable[tile] = true;
    }

    public void AddStart(int tile)
    {
        Tile.type[tile] = "Start";
        Tile.Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Stairs/Start");
        PlayerMovement.tilePos = tile;
        PlayerMovement.xPos = tile % 40;
        PlayerMovement.yPos = tile / 40;
        Tile.passable[tile] = true;
    }

    public void AddExit(int tile)
    {
        Tile.type[tile] = "Exit";
        Tile.Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Stairs/Exit");
        Tile.passable[tile] = true;
    }
}
