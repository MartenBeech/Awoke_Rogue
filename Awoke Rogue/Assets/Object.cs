using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour
{
    public static bool gateOpened = false;
    public void EnemyClicked()
    {
        string name = this.name.Replace("Enemy", "");
        EnemySelected(int.Parse(name));
    }
    private void EnemySelected(int i)
    {
        Debug.Log((Enemy.enemies[i].title) + i.ToString() + (FogOfWar.scouted[i] ? " ScoutedTrue" : "ScoutedFalse"));
        PlayerAttack attack = new PlayerAttack();
        attack.UseAbility(i);
    }

    //public void ArtifactClicked()
    //{
    //    ArtifactSelected(this.name);
    //}

    //private void ArtifactSelected(string name)
    //{
    //    Artifact.Title parsedEnum = (Artifact.Title)System.Enum.Parse(typeof(Artifact.Title), name);
    //    Debug.Log(parsedEnum);
    //}

    public void TileClicked()
    {
        string name = EventSystem.current.currentSelectedGameObject.name.Replace("Tile", "");
        TileSelected(int.Parse(name));
    }

    private void TileSelected(int i)
    {
        Debug.Log(Tile.type[i] + i.ToString() + (FogOfWar.scouted[i] ? " ScoutedTrue" : "ScoutedFalse"));
        if (Tile.type[i] == Tile.Type.TreasureGateClosed && PlayerStat.keyObtained)
        {
            Distance distance = new Distance();
            if (distance.GetDistanceToPlayerSquare(i) <= 1)
            {
                OpenGate(i);
            }
        }
    }

    private void OpenGate(int i)
    {
        if (Tile.type[i] == Tile.Type.TreasureGateClosed)
        {
            gateOpened = true;

            Tile tile = new Tile();
            tile.AddGateOpen(i);

            AnimaText text = new AnimaText();
            text.ShowText(i, "Gate Opened", Color.cyan);

            UI ui = new UI();
            ui.EndTurn();
        }
    }

    public void PlayerClicked()
    {
        if (Tile.type[PlayerMovement.tilePos] == Tile.Type.End)
        {
            if (PlayerStat.bossKilled)
            {
                Level level = new Level();
                level.WinLevel();
            }
            else
            {
                AnimaText text = new AnimaText();
                text.ShowText(PlayerMovement.tilePos, "Boss still alive", Color.red);
            }
        }
    }
}
