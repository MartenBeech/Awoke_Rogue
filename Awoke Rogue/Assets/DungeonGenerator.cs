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
        AddRoomSection(2, 1);

        AddStartAndExit();
        AddEnemies(0);
    }

    private void FillWithWalls()
    {
        for (int i = 0; i < Tile.Tiles.Length; i++)
        {
            Tile tile = new Tile();
            tile.AddWall(i);
        }
    }

    private void AddRoomSection(int roomAmount, int treasureRoom)
    {
        int[] centerX = new int[roomAmount];
        int[] centerY = new int[roomAmount];
        int xs, xe, ys, ye, XS, XE, YS, YE;

        for (int i = treasureRoom; i < roomAmount; i++)
        {
            int xCenter = rng.Range(0, 39);
            int yCenter = rng.Range(0, 39);
            XS = xs = rng.Range(xCenter - 5, xCenter - 1);
            XE = xe = rng.Range(xCenter, xCenter + 4);
            YS = ys = rng.Range(yCenter - 5, yCenter - 1);
            YE = ye = rng.Range(yCenter, yCenter + 4);

            xs += SetIntervalOffset(XS);
            xe += SetIntervalOffset(XS);
            xs -= SetIntervalOffset(XE);
            xe -= SetIntervalOffset(XE);

            ys += SetIntervalOffset(YS);
            ye += SetIntervalOffset(YS);
            ys -= SetIntervalOffset(YE);
            ye -= SetIntervalOffset(YE);

            AddRoom(xs, xe, ys, ye);
            centerX[i] = Mathf.RoundToInt(xs + ((xe - xs) / 2));
            centerY[i] = Mathf.RoundToInt(ys + ((ye - ys) / 2));
        }

        for (int i = 0; i < treasureRoom; i++)
        {
            int xCenter = rng.Range(0, 40);
            int yCenter = rng.Range(0, 40);

            int roomType = rng.Range(0, 2);
            if (roomType == 0)
            {
                XS = xs = xCenter - 6;
                XE = xe = xCenter + 5;
                YS = ys = yCenter - 4;
                YE = ye = yCenter + 3;
            }
            else
            {
                XS = xs = xCenter - 4;
                XE = xe = xCenter + 3;
                YS = ys = yCenter - 6;
                YE = ye = yCenter + 5;
            }

            xs += SetIntervalOffset(XS);
            xe += SetIntervalOffset(XS);
            xs -= SetIntervalOffset(XE);
            xe -= SetIntervalOffset(XE);

            ys += SetIntervalOffset(YS);
            ye += SetIntervalOffset(YS);
            ys -= SetIntervalOffset(YE);
            ye -= SetIntervalOffset(YE);

            AddRoom(xs, xe, ys, ye, true, roomType);
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

    private void AddRoom(int xStart, int xEnd, int yStart, int yEnd, bool treasureRoom = false, int roomType = 0)
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

        for (int y = yStart; y <= yEnd; y++)
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                tile.AddFloor(x + (40 * y));
            }
        }

        if (treasureRoom)
        {
            for (int y = yStart; y <= yEnd; y++)
            {
                for (int x = xStart; x <= xEnd; x++)
                {
                    if (y != yStart && y != yEnd && x != xStart && x != xEnd)
                    {
                        if (y == yStart + 1 || y == yEnd - 1 || x == xStart + 1 || x == xEnd - 1)
                        {
                            tile.AddWall(x + (40 * y), "Treasure");
                        }
                        else
                        {
                            if (roomType == 0)
                            {
                                tile.AddFloor(x + (40 * y), (x - xStart - 2) + ((y - yStart - 2) * 8), "Treasure");
                            }
                            else if (roomType == 1)
                            {
                                tile.AddFloor(x + (40 * y), (x - xStart - 2) + ((y - yStart - 2) * 4), "Treasure");
                            }
                        }
                    }
                }
            }
        }
    }

    private void AddPath(int xStart, int xEnd, int yStart, int yEnd)
    {
        Tile tile = new Tile();

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

            if (!Tile.type[xpos + (40 * ypos)].Contains("Treasure"))
            {
                tile.AddFloor(xpos + (40 * ypos));
            }
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
        while (Tile.type[rnd] != "Floor" || !Tile.passable[rnd]);
        tile.AddStart(rnd);

        do
        {
            rnd = rng.Range(0, 1600);
        }
        while (Tile.type[rnd] != "Floor" || !Tile.passable[rnd]);
        tile.AddExit(rnd);
    }

    private int SetIntervalOffset(int tile)
    {
        if (tile < 0)
            return -tile;
        if (tile > 39)
            return tile - 39;
        return 0;
    }

    private void AddEnemies(int amount)
    {
        Enemy enemy = new Enemy();

        for (int i = 0; i < amount; i++)
        {
            enemy.SummonRandomEnemy(0);
        }
    }
}
