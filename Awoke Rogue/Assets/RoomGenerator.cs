using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomGenerator : MonoBehaviour
{
    
    public void GenerateRoom()
    {
        FillWithWall();

        AddImageToTiles();
    }

    private void FillWithWall()
    {
        for (int i = 0; i < Tile.Tiles.Length; i++)
        {
            Tile.type[i] = "Wall";
        }
    }

    private void AddPath(int xStart, int xEnd, int yStart, int yEnd)
    {

    }

    private void AddImageToTiles()
    {
        for (int i = 0; i < Tile.Tiles.Length; i++)
        {
            if (Tile.type[i] == "Wall")
            {
                Tile.Tiles[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Walls/Wall");
            }
        }
        
    }
}
