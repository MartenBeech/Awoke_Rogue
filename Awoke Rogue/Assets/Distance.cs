using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public int GetDistanceToPlayer(int tile)
    {
        int xPos = tile % 40;
        int yPos = tile / 40;
        int xDis = Mathf.Abs(xPos - PlayerMovement.xPos);
        int yDis = Mathf.Abs(yPos - PlayerMovement.yPos);

        return xDis + yDis;
    }

    public int GetDistanceToPlayerSquare(int tile)
    {
        int xPos = tile % 40;
        int yPos = tile / 40;
        int xDis = Mathf.Abs(xPos - PlayerMovement.xPos);
        int yDis = Mathf.Abs(yPos - PlayerMovement.yPos);

        if (xDis >= yDis)
        {
            return xDis;
        }
        else
        {
            return yDis;
        }
        
    }

    public List<int> GetEnemiesAroundPlayer(int range)
    {
        List<int> tiles = new List<int>();
        for (int x = -range; x <= range; x++)
        {
            for (int y = -range; y <= range; y++)
            {
                if (Mathf.Abs(x) + Mathf.Abs(y) <= range)
                {
                    if (PlayerMovement.tilePos + (x + (y * 40)) >= 0 && PlayerMovement.tilePos + (x + (y * 40)) < 1600)
                    {
                        if (Enemy.occupied[PlayerMovement.tilePos + (x + (y * 40))])
                        {
                            tiles.Add(PlayerMovement.tilePos + (x + (y * 40)));
                        }
                    }
                }
            }
        }
        return tiles;
    }
}
