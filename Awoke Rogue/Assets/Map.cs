using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public static GameObject[] Maps = new GameObject[Tile.SIZE];

    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                Maps[j + (40 * i)] = GameObject.Find("MapsHorizontal (" + i + ")/Map (" + j + ")");
                Maps[j + (40 * i)].name = "Map" + (j + (40 * i));
            }
        }
    }

    public void ScoutMap(int center, int range)
    {
        int xPos = center % 40;
        int yPos = center / 40;

        for (int x = xPos - range; x < xPos + range; x++)
        {
            if (x >= 0 && x < 40)
            {
                for (int y = yPos - range; y < yPos + range; y++)
                {
                    if (y >= 0 && y < 40)
                    {
                        ScoutTile(x + (y * 40));
                    }
                }
            } 
        }
    }

    public void ScoutTile(int i)
    {
        if (i == PlayerMovement.tilePos)
        {
            Map.Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(120 / 360f, 1f, 1f); //Green
        }
        else if (Enemy.occupied[i] && FogOfWar.scouted[i])
        {
            Map.Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(0 / 360f, 1f, 1f); //Red
        }

        else
        {
            switch (Tile.type[i])
            {
                case Tile.Type.DungeonWall:
                case Tile.Type.TreasureWall:
                    Map.Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(0 / 360f, 1f, 0f); //Black
                    break;

                case Tile.Type.DungeonFloor:
                    Map.Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(240 / 360f, 1f, 1f); //DarkBlue
                    break;

                case Tile.Type.TreasureFloor:
                    Map.Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(45 / 360f, 1f, 1f); //YellowOrange
                    break;

                case Tile.Type.Start:
                    Map.Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(180 / 360f, 0.75f, 0.75f); //LightCyan
                    break;

                case Tile.Type.End:
                    Map.Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(180 / 360f, 1f, 0.5f); //DarkCyan
                    break;

                case Tile.Type.TreasureGateClosed:
                case Tile.Type.TreasureGateOpen:
                    Map.Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(270 / 360f, 1f, 1f); //Purple
                    break;
            }
        }
    }
}
