using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static GameObject Cam;
    public static GameObject Board;
    public static GameObject Info;

    public static int level = 0;

    private void Start()
    {
        Cam = GameObject.Find("Main Camera");
        Board = GameObject.Find("CanvasDungeon");
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
        Cam.transform.position = new Vector3(Board.transform.position.x, Board.transform.position.y, -10);
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
        NewLevel();
    }
}
