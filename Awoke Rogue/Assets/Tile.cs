using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public const int SIZE = 1600;
    Rng rng = new Rng();
    public static GameObject[] Tiles = new GameObject[SIZE];

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
                //Tiles[j + (40 * i)].GetComponentInChildren<Button>().onClick = TileClicked();
            }
        }
    }

    public void AddWall(int tile, Type _Type = Type.Dungeon)
    {
        if (_Type == Type.Dungeon)
        {
            type[tile] = Type.DungeonWall;
            Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Walls/WallDungeon");
        }
        else if (_Type == Type.Treasure)
        {
            type[tile] = Type.TreasureWall;
            Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Walls/WallTreasure");
        }
        passable[tile] = false;
    }

    public void AddFloor(int tile, int i = 0, Type _Type = Type.Dungeon)
    {
        if (_Type == Type.Dungeon)
        {
            type[tile] = Type.DungeonFloor; Rng rng = new Rng();
            Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Floors/FloorDungeon (" + rng.Range(0, 16) + ")");
        }
        else if (_Type == Type.Treasure)
        {
            type[tile] = Type.TreasureFloor;
            Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Floors/FloorTreasure (" + i + ")");
        }
        passable[tile] = true;
    }

    public void AddStart(int tile)
    {
        type[tile] = Type.Start;
        Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Stairs/Start");
        PlayerMovement.tilePos = tile;
        PlayerMovement.xPos = tile % 40;
        PlayerMovement.yPos = tile / 40;
        passable[tile] = true;
    }

    public void AddExit(int tile)
    {
        type[tile] = Type.End;
        Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Stairs/Exit");
        passable[tile] = true;
    }

    public void AddGateClosed(int tile)
    {
        Rng rng = new Rng();
        type[tile] = Type.TreasureGateClosed;
        Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Objects/Gate" + rng.Range(0, 3));
        passable[tile] = false;
    }

    public void AddGateOpen(int tile)
    {
        type[tile] = Type.TreasureGateOpen;
        Tiles[tile].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Objects/GateOpen");
        passable[tile] = true;
    }

    public void RotateTile(GameObject gameObject, float angle)
    {
        angle = (angle * 2 * Mathf.PI / 360);
        gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, Mathf.Sin(angle / 2), Mathf.Cos(angle / 2));
        gameObject.GetComponentInChildren<Text>().transform.rotation = new Quaternion(gameObject.GetComponentInChildren<Text>().transform.rotation.x, gameObject.GetComponentInChildren<Text>().transform.rotation.y, 0, 1);
    }

    public void TileClicked()
    {
        
    }
}
