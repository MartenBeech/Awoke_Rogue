using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static GameObject Info;

    public static int level = 0;

    private void Start()
    {
        Info = GameObject.Find("StartGame");
    }

    public void NewLevel()
    {
        level++;

        Enemy enemy = new Enemy();
        for (int i = 0; i < Tile.SIZE; i++)
        {
            if (Enemy.occupied[i])
            {
                enemy.Destroy(i);
            }
        }
        CameraMain.Cam.GetComponentInChildren<CameraFollow>().enabled = true;
        if (PlayerStat.scoutRange >= 5)
        {
            CameraMain.Cam.GetComponentInChildren<Camera>().orthographicSize = (PlayerStat.scoutRange * 10) + 5;
        }
        else
        {
            CameraMain.Cam.GetComponentInChildren<Camera>().orthographicSize = 50;
        }
        

        DungeonGenerator dungeon = new DungeonGenerator();
        dungeon.GenerateDungeon();

        Map map = new Map();
        map.HideMap();

        PlayerMovement playerMovement = new PlayerMovement();
        playerMovement.MovePlayer(PlayerMovement.tilePos, PlayerMovement.tilePos);

        FogOfWar fow = new FogOfWar();
        fow.ScoutPath(PlayerMovement.tilePos, PlayerStat.scoutRange);
        fow.ScoutTiles();
        fow.ScoutEnemies();

        map.UpdateMap();

        Turn turn = new Turn();
        turn.PlayerTurn();

        PlayerStat playerStat = new PlayerStat();
        playerStat.ResetStats();
    }

    public void WinLevel()
    {
        PlayerStat playerStat = new PlayerStat();
        playerStat.ResetStats();
        Shop shop = new Shop();
    }
}
