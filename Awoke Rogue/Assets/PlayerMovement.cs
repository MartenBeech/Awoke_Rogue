using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static GameObject Player;
    public static int xPos;
    public static int yPos;
    public static int tilePos;
    public static bool playerTurn = true;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Player.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Players/Archer");
    }
    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            if (tilePos - 40 >= 0)
            {
                if (Tile.passable[tilePos - 40])
                {
                    MovePlayer(tilePos, tilePos - 40);
                }
            }
        }
        else if (Input.GetKeyDown("s"))
        {
            if (tilePos + 40 < 1600)
            {
                if (Tile.passable[tilePos + 40])
                {
                    MovePlayer(tilePos, tilePos + 40);
                }
            }
        }
        else if (Input.GetKeyDown("a"))
        {
            if (tilePos % 40 != 0)
            {
                if (Tile.passable[tilePos - 1])
                {
                    MovePlayer(tilePos, tilePos - 1);
                }
            }
        }
        else if (Input.GetKeyDown("d"))
        {
            if (tilePos % 40 != 39)
            {
                if (Tile.passable[tilePos + 1])
                {
                    MovePlayer(tilePos, tilePos + 1);
                }
            }
        }
    }

    public void MovePlayer(int from, int to)
    {
        playerTurn = false;

        tilePos = to;
        PlayerMovement.xPos = tilePos % 40;
        PlayerMovement.yPos = tilePos / 40;

        Player.GetComponentInChildren<AnimaUnit>().startPoint = Tile.Tiles[from];
        Player.GetComponentInChildren<AnimaUnit>().endPoint = Tile.Tiles[to];
        Player.GetComponentInChildren<AnimaUnit>().counter = 0.19f;

        Tile.passable[from] = true;
        Tile.passable[to] = false;
    }
}
