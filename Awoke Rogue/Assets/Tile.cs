using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    const int SIZE = 1600;
    public static GameObject[] Tiles = new GameObject[SIZE];

    public static string[] type = new string[SIZE];

    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Tiles[j + (40 * i)] = GameObject.Find("TilesHorizontal (" + i + ")/Tile (" + j + ")");
            }
        }

        RoomGenerator room = new RoomGenerator();
        room.GenerateRoom();
    }
}
