using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Object : MonoBehaviour
{
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
    }

    private void TileSelected(int i)
    {
        Debug.Log(Tile.type[i] + i.ToString());
    }
}
