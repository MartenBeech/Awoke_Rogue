using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameObject cam;
    private GameObject board;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        board = GameObject.Find("CanvasDungeon");
    }
    public void StartGameClicked()
    {
        cam.transform.position = new Vector3(board.transform.position.x, board.transform.position.y, -10);
        DungeonGenerator dungeon = new DungeonGenerator();
        dungeon.GenerateDungeon();

        PlayerMovement playerMovement = new PlayerMovement();
        playerMovement.MovePlayer(PlayerMovement.tilePos, PlayerMovement.tilePos);
    }
}
