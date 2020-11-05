using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public static GameObject[] Maps = new GameObject[Tile.SIZE];
    public static bool[] scouted = new bool[1600];

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

    public void UpdateMap()
    {
        for (int i = 0; i < Tile.SIZE; i++)
        {
            if (scouted[i])
            {
                ScoutTile(i);
            }
        }
    }

    public void HideMap()
    {
        for (int i = 0; i < Tile.SIZE; i++)
        {
            Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(0 / 360f, 0f, 0.5f); //Gray
            scouted[i] = false;
        }
    }

    public void ScoutTile(int i)
    {
        Tile.Tiles[i].GetComponentInChildren<Image>().sprite = Tile.images[i];

        if (i == PlayerMovement.tilePos)
        {
            Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(120 / 360f, 1f, 1f); //Green
        }
        else if (Enemy.occupied[i] && FogOfWar.scouted[i])
        {
            Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(0 / 360f, 1f, 1f); //Red
        }

        else
        {
            switch (Tile.type[i])
            {
                case Tile.Type.DungeonWall:
                    Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(0 / 360f, 1f, 0f); //Black
                    break;

                case Tile.Type.DungeonFloor:
                    Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(240 / 360f, 1f, 1f); //DarkBlue
                    break;

                case Tile.Type.TreasureWall:
                    Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(45 / 360f, 1f, 1f); //YellowOrange
                    break;

                case Tile.Type.TreasureFloor:
                case Tile.Type.TreasureGateClosed:
                case Tile.Type.TreasureGateOpen:
                    Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(45 / 360f, 0.6f, 0.6f); //DarkYellowOrange
                    break;

                case Tile.Type.Start:
                    Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(180 / 360f, 0.75f, 0.75f); //LightCyan
                    break;

                case Tile.Type.End:
                    Maps[i].GetComponentInChildren<Image>().color = Color.HSVToRGB(180 / 360f, 1f, 0.5f); //DarkCyan
                    break;
            }
        }
    }
}
