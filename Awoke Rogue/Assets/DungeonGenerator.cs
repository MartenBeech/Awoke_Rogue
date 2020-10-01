using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonGenerator : MonoBehaviour
{
    Rng rng = new Rng();
    public void GenerateDungeon()
    {
        FillWithWalls();
        AddRoomSection(30);

        AddStartAndExit();

    }

    private void FillWithWalls()
    {
        for (int i = 0; i < Tile.Tiles.Length; i++)
        {
            Tile tile = new Tile();
            tile.AddWall(i);
        }
    }

    private void AddRoomSection(int roomAmount)
    {
        int[] centerX = new int[roomAmount];
        int[] centerY = new int[roomAmount];
        int xs, xe, ys, ye;

        for (int i = 0; i < roomAmount; i++)
        {
            int xCenter = rng.Range(0, 39);
            int yCenter = rng.Range(0, 39);
            AddRoom(xs = rng.Range(xCenter - 5, xCenter - 1), xe = rng.Range(xCenter, xCenter + 4), ys = rng.Range(yCenter - 5, yCenter - 1), ye = rng.Range(yCenter, yCenter + 4));
            centerX[i] = Mathf.RoundToInt(xs + ((xe - xs) / 2));
            centerY[i] = Mathf.RoundToInt(ys + ((ye - ys) / 2));
        }

        for (int i = 0; i < roomAmount; i++)
        {
            if (i == roomAmount - 1)
            {
                AddPath(centerX[i], centerX[0], centerY[i], centerY[0]);
            }
            else
            {
                AddPath(centerX[i], centerX[i + 1], centerY[i], centerY[i + 1]);
            }
            
        }
    }

    private void AddRoom(int xStart, int xEnd, int yStart, int yEnd)
    {
        Tile tile = new Tile();
        if (xEnd < xStart)
        {
            int temp = xEnd;
            xEnd = xStart;
            xStart = temp;
        }
        if (yEnd < yStart)
        {
            int temp = yEnd;
            yEnd = yStart;
            yStart = temp;
        }
        xStart = SetTileInsideInterval(xStart);
        xEnd = SetTileInsideInterval(xEnd);
        yStart = SetTileInsideInterval(yStart);
        yEnd = SetTileInsideInterval(yEnd);

        for (int y = yStart; y <= yEnd; y++)
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                tile.AddTerrain(x + (40 * y));
            }
        }
    }

    private void AddPath(int xStart, int xEnd, int yStart, int yEnd)
    {
        Tile tile = new Tile();
        xStart = SetTileInsideInterval(xStart);
        xEnd = SetTileInsideInterval(xEnd);
        yStart = SetTileInsideInterval(yStart);
        yEnd = SetTileInsideInterval(yEnd);

        List<char> movement = new List<char>();
        for (int i = yStart; i < yEnd; i++)
        {
            movement.Add('N');
        }
        for (int i = xStart; i < xEnd; i++)
        {
            movement.Add('E');
        }
        for (int i = yEnd; i < yStart; i++)
        {
            movement.Add('S');
        }
        for (int i = xEnd; i < xStart; i++)
        {
            movement.Add('W');
        }

        int movementCount = movement.Count;
        int xpos = xStart;
        int ypos = yStart;
        tile.AddTerrain(xpos + (40 * ypos));
        for (int i = 0; i < movementCount; i++)
        {
            int rnd = rng.Range(0, movement.Count);
            if (movement[rnd] == 'N')
            {
                ypos++;
            }
            else if (movement[rnd] == 'S')
            {
                ypos--;
            }
            else if (movement[rnd] == 'E')
            {
                xpos++;
            }
            else if (movement[rnd] == 'W')
            {
                xpos--;
            }
            tile.AddTerrain(xpos + (40 * ypos));
            movement.RemoveAt(rnd);
        }
    }

    public void AddStartAndExit()
    {
        Tile tile = new Tile();
        int rnd;

        do
        {
            rnd = rng.Range(0, 1600);
        }
        while (Tile.type[rnd] != "Terrain");
        tile.AddStart(rnd);

        do
        {
            rnd = rng.Range(0, 1600);
        }
        while (Tile.type[rnd] != "Terrain");
        tile.AddExit(rnd);
    }

    private int SetTileInsideInterval(int tile)
    {
        if (tile < 0)
            tile = 0;
        if (tile > 39)
            tile = 39;
        return tile;
    }
}
