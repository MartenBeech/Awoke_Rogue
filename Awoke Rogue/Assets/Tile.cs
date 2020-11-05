using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public const int SIZE = 1600;
    Rng rng = new Rng();
    public static GameObject[] Tiles = new GameObject[SIZE];
    public static Sprite[] images = new Sprite[SIZE];

    public enum Type 
    {
        Dungeon, Treasure, 
        DungeonWall, DungeonFloor, TreasureWall, TreasureFloor,
        Start, End,
        TreasureGateOpen, TreasureGateClosed
    };
    public static Type[] type = new Type[SIZE];
    public static bool[] passable = new bool[SIZE];

    

    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Tiles[j + (40 * i)] = GameObject.Find("TilesHorizontal (" + i + ")/Tile (" + j + ")");
                Tiles[j + (40 * i)].name = "Tile" + (j + (40 * i));
            }
        }
    }

    public void AddWall(int tile, Type _Type = Type.Dungeon)
    {
        if (_Type == Type.Dungeon)
        {
            type[tile] = Type.DungeonWall;
            images[tile] = Resources.Load<Sprite>("Walls/WallDungeon");
        }
        else if (_Type == Type.Treasure)
        {
            type[tile] = Type.TreasureWall;
            images[tile] = Resources.Load<Sprite>("Walls/WallTreasure");
        }
        passable[tile] = false;
    }

    public void AddFloor(int tile, int i = 0, Type _Type = Type.Dungeon)
    {
        if (_Type == Type.Dungeon)
        {
            type[tile] = Type.DungeonFloor; 
            Rng rng = new Rng();
            images[tile] = Resources.Load<Sprite>("Floors/FloorDungeon (" + rng.Range(0, 16) + ")");
        }
        else if (_Type == Type.Treasure)
        {
            type[tile] = Type.TreasureFloor;
            images[tile] = Resources.Load<Sprite>("Floors/FloorTreasure (" + i + ")");
        }
        passable[tile] = true;
    }

    public void AddStart(int tile)
    {
        type[tile] = Type.Start;
        images[tile] = Resources.Load<Sprite>("Stairs/Start");
        PlayerMovement.tilePos = tile;
        PlayerMovement.xPos = tile % 40;
        PlayerMovement.yPos = tile / 40;
        passable[tile] = true;
    }

    public void AddExit(int tile)
    {
        type[tile] = Type.End;
        images[tile] = Resources.Load<Sprite>("Stairs/Exit");
        passable[tile] = true;
    }

    public void AddGateClosed(int tile)
    {
        Rng rng = new Rng();
        type[tile] = Type.TreasureGateClosed;
        images[tile] = Resources.Load<Sprite>("Objects/Gate" + rng.Range(0, 3));
        passable[tile] = false;
    }

    public void AddGateOpen(int tile)
    {
        type[tile] = Type.TreasureGateOpen;
        images[tile] = Resources.Load<Sprite>("Objects/GateOpen");
        passable[tile] = true;
    }

    public void RotateTile(GameObject gameObject, float angle)
    {
        angle = (angle * 2 * Mathf.PI / 360);
        gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, Mathf.Sin(angle / 2), Mathf.Cos(angle / 2));
    }
}
