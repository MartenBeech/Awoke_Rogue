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
        Camera.Cam.GetComponentInChildren<CameraFollow>().enabled = true;
        DungeonGenerator dungeon = new DungeonGenerator();
        dungeon.GenerateDungeon();

        PlayerMovement playerMovement = new PlayerMovement();
        playerMovement.MovePlayer(PlayerMovement.tilePos, PlayerMovement.tilePos);

        FogOfWar fow = new FogOfWar();
        fow.ScoutPath(PlayerMovement.tilePos, PlayerStat.scoutRange);
        fow.ScoutTiles();
        fow.ScoutEnemies();

        Map map = new Map();
        map.HideMap();
        map.ScoutMap(PlayerMovement.tilePos, 40);

        Turn turn = new Turn();
        turn.PlayerTurn();

        PlayerStat playerStat = new PlayerStat();
        playerStat.ResetStats();
    }

    public void WinLevel()
    {
        Shop shop = new Shop();
        
    }
}
