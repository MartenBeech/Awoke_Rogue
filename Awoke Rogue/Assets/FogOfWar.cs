using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogOfWar : MonoBehaviour
{
    public static bool[] scouted = new bool[1600];

    public FogOfWar()
    {
        for (int i = 0; i < Tile.SIZE; i++)
        {
            scouted[i] = false;
        }
    }
    private int GetAvailableTile(int X, int Y, int center)
    {
        if (center + (Y * 40) >= 1600)
            return 1600;
        if (center + (Y * 40) < 0)
            return 1600;
        if (center % 40 < -X)
            return 1600;
        if (40 - (center % 40) <= X)
            return 1600;

        return center + X + (Y * 40);
    }

    public void ScoutPath(int center, int range, bool farSight)
    {
        if (!farSight)
        {
            int tile;
            if (range <= 0)
                return;

            tile = GetAvailableTile(-1, 0, center);
            if (tile < 1600)
            {
                scouted[tile] = true;
                if (Tile.passable[tile])
                {
                    ScoutPath(tile, range - 1, farSight);
                }
            }

            tile = GetAvailableTile(1, 0, center);
            if (tile < 1600)
            {
                scouted[tile] = true;
                if (Tile.passable[tile])
                {
                    ScoutPath(tile, range - 1, farSight);
                }
            }

            tile = GetAvailableTile(0, -1, center);
            if (tile < 1600)
            {
                scouted[tile] = true;
                if (Tile.passable[tile])
                {
                    ScoutPath(tile, range - 1, farSight);
                }
            }

            tile = GetAvailableTile(0, 1, center);
            if (tile < 1600)
            {
                scouted[tile] = true;
                if (Tile.passable[tile])
                {
                    ScoutPath(tile, range - 1, farSight);
                }
            }
        }

        else if (farSight)
        {
            List<int> tileList = new List<int>();

            for (int Y = -range; Y <= range; Y++)
            {
                for (int X = -range; X <= range; X++)
                {
                    if (Mathf.Abs(X) + Mathf.Abs(Y) <= range)
                    {
                        int tile = GetAvailableTile(X, Y, center);
                        if (tile < 1600)
                            tileList.Add(tile);
                    }
                }
            }

            for (int i = 0; i < tileList.Count; i++)
            {
                if (Tile.passable[tileList[i]])
                {
                    scouted[tileList[i]] = true;
                }
            }
        }

        scouted[center] = true;
        Scout();
    }

    private void Scout()
    {
        for (int i = 0; i < Tile.SIZE; i++)
        {
            if (!scouted[i])
            {
                Tile.Tiles[i].GetComponentInChildren<Image>().color = Color.gray;
            }
            else
            {
                Tile.Tiles[i].GetComponentInChildren<Image>().color = Color.white;
            }
        }
    }
}
