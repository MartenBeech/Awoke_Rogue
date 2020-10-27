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

    public void TileClicked()
    {
        string name = EventSystem.current.currentSelectedGameObject.name.Replace("Tile", "");
        TileSelected(int.Parse(name));
    }

    private void EnemySelected(int i)
    {
        Debug.Log((Enemy.enemies[i].title) + i.ToString());
        PlayerAttack attack = new PlayerAttack();
        attack.UseAbility(i);
    }

    private void TileSelected(int i)
    {
        Debug.Log(Tile.type[i] + i.ToString());
    }

    private void OpenGate()
    {
        for (int i = 0; i < Tile.SIZE; i++)
        {
            if (Tile.type[i] == Tile.Type.TreasureGateClosed)
            {
                Tile.type[i] = Tile.Type.TreasureGateOpen;
                gateOpened = true;
                Tile.Tiles[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Objects/GateOpen");
                Tile.passable[i] = true;

                break;
            }
        }
    }
}
