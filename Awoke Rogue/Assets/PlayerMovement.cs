using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static GameObject Player;
    public static int xPos;
    public static int yPos;
    public static int tilePos;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Player.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Players/Archer");
    }
    private void Update()
    {
        if (Turn.currentTurn == Turn.CurrentTurn.Player)
        {
            if (Input.GetKeyDown("w"))
            {
                if (tilePos - 40 >= 0)
                {
                    if (Tile.passable[tilePos - 40])
                    {
                        MovePlayer(tilePos, tilePos - 40);
                    }
                }
            }
            else if (Input.GetKeyDown("s"))
            {
                if (tilePos + 40 < 1600)
                {
                    if (Tile.passable[tilePos + 40])
                    {
                        MovePlayer(tilePos, tilePos + 40);
                    }
                }
            }
            else if (Input.GetKeyDown("a"))
            {
                if (tilePos % 40 != 0)
                {
                    if (Tile.passable[tilePos - 1])
                    {
                        MovePlayer(tilePos, tilePos - 1);
                    }
                }
            }
            else if (Input.GetKeyDown("d"))
            {
                if (tilePos % 40 != 39)
                {
                    if (Tile.passable[tilePos + 1])
                    {
                        MovePlayer(tilePos, tilePos + 1);
                    }
                }
            }
        }
    }

    public void MovePlayer(int from, int to, float counter = 0.25f)
    {
        tilePos = to;
        xPos = tilePos % 40;
        yPos = tilePos / 40;

        Player.name = "Player" + to.ToString();

        AnimaUnit animaUnit = new AnimaUnit();
        animaUnit.MoveUnit(Player, from, to, counter);

        Tile.passable[from] = true;
        Tile.passable[to] = false;

        PlayerStat playerStat = new PlayerStat();
        playerStat.GainRage(-1);

        if (Artifact.titles[to] != Artifact.Title.None)
        {
            Artifact.Title title = Artifact.titles[to];

            Artifact artifact = new Artifact();
            artifact.Destroy(to);

            AbilityEffect ability = new AbilityEffect();
            ability.GainArtifact(title);

            
        }

        Turn.currentTurn = Turn.CurrentTurn.PlayerNeutral;
    }
}
