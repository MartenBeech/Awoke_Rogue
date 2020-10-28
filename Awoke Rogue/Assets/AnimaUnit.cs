using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaUnit : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    public float counter = 100f;
    void Update()
    {
        if (counter == 100f)
        {

        }
        else if (counter > 0)
        {
            Vector3 dir = endPoint.transform.position - startPoint.transform.position;
            float dist = Mathf.Sqrt(
                Mathf.Pow(endPoint.transform.position.x - startPoint.transform.position.x, 2) +
                Mathf.Pow(endPoint.transform.position.y - startPoint.transform.position.y, 2));
            this.transform.Translate(dir.normalized * dist * (Time.deltaTime) * 4);
            counter -= Time.deltaTime;

            if (counter <= 0)
            {
                counter = 100f;
                this.transform.position = new Vector3(endPoint.transform.position.x, endPoint.transform.position.y, -0.01f);

                Turn turn = new Turn();
                if (Turn.currentTurn == Turn.CurrentTurn.PlayerNeutral)
                {
                    turn.EnemyTurn();
                    FogOfWar fow = new FogOfWar();
                    fow.ScoutPath(PlayerMovement.tilePos, PlayerStat.scoutRange, false);
                    fow.ScoutTiles();
                    fow.ScoutEnemies();
                }
                else if (Turn.currentTurn == Turn.CurrentTurn.EnemyNeutral)
                {
                    turn.PlayerTurn();
                }
            }
        }
    }

    public void MoveUnit(GameObject gameObject, int from, int to, float counter = 0.25f)
    {
        gameObject.GetComponentInChildren<AnimaUnit>().startPoint = Tile.Tiles[from];
        gameObject.GetComponentInChildren<AnimaUnit>().endPoint = Tile.Tiles[to];
        gameObject.GetComponentInChildren<AnimaUnit>().counter = counter;
    }
}

