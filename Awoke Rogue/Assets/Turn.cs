using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public enum CurrentTurn
    {
        Player, Enemy, PlayerNeutral, EnemyNeutral
    };
    public static CurrentTurn currentTurn;


    public void PlayerTurn()
    {
        currentTurn = CurrentTurn.Player;
    }

    public void EnemyTurn()
    {
        currentTurn = CurrentTurn.Enemy;
        Distance distance = new Distance();
        List<int> enemies = distance.GetEnemiesAroundPlayer(Ability.stealthRange);

        if (enemies.Count == 0)
        {
            PlayerTurn();
        }
        else
        {
            List<int> sortedEnemies = new List<int>();
            int count = 0;
            for (int range = 1; range <= Ability.stealthRange; range++)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (distance.GetDistanceToPlayer(enemies[i]) == range)
                    {
                        sortedEnemies.Add(enemies[i]);
                        enemies.RemoveAt(i);
                        i--;
                    }
                }
            }

            EnemyUnit enemyUnit = new EnemyUnit();
            for (int i = 0; i < sortedEnemies.Count; i++)
            {
                enemyUnit.TakeTurn(sortedEnemies[i]);
            }
            PlayerTurn();
        }
    }
}
