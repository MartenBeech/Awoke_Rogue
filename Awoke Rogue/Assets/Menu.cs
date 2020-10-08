using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameObject Cam;
    private GameObject Board;
    public static GameObject Info;

    private void Start()
    {
        Cam = GameObject.Find("Main Camera");
        Board = GameObject.Find("CanvasDungeon");
        Info = GameObject.Find("StartGame");
    }
    public void StartGameClicked()
    {
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
        fow.ScoutPath(PlayerMovement.tilePos, PlayerStat.scoutRange, false);

        Turn turn = new Turn();
        turn.PlayerTurn();
    }
}
