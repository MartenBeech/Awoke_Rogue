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
        for (int i = 0; i < Tile.SIZE; i++)
        {
            if (Enemy.occupied[i])
            {
                if (Enemy.enemies[i].cantAttack > 0)
                {
                    Enemy.enemies[i].cantAttack--;
                }
                if (Enemy.enemies[i].cantMove > 0)
                {
                    Enemy.enemies[i].cantMove--;
                }
            }
        }

        for (int i = 0; i < PlayerAttack.SIZE; i++)
        {
            PlayerAttack attack = new PlayerAttack();
            if (PlayerAttack.cooldown[i] > 0)
            {
                PlayerAttack.cooldown[i]--;
                attack.DisplayAbility(i);
            }
        }
    }

    public void EnemyTurn()
    {
        currentTurn = CurrentTurn.Enemy;
        Distance distance = new Distance();
        EnemyUnit enemyUnit = new EnemyUnit();

        //ENEMIES MOVE OR ATTACK
        List<int> enemies = distance.GetEnemiesAroundPlayer(PlayerStat.stealthRange);

        if (enemies.Count == 0)
        {
            PlayerTurn();
            return;
        }
        else
        {
            List<int> sortedEnemies = new List<int>();
            for (int range = 1; range <= PlayerStat.stealthRange; range++)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (distance.GetDistanceToPlayer(enemies[i]) == range && !(Tile.type[Enemy.enemies[enemies[i]].tilePos] == Tile.Type.TreasureFloor && !Object.gateOpened))
                    {
                        sortedEnemies.Add(enemies[i]);
                        enemies.RemoveAt(i);
                        i--;
                    }
                }
            }
            
            for (int i = 0; i < sortedEnemies.Count; i++)
            {
                if (Enemy.enemies[sortedEnemies[i]].preparing)
                {
                    enemyUnit.AttackAction(sortedEnemies[i]);
                    if (Enemy.enemies[sortedEnemies[i]].cantAttack == 0)
                    {
                        Enemy.enemies[sortedEnemies[i]].cantAttack += Enemy.enemies[sortedEnemies[i]].cooldown;
                    }
                }
                else
                {
                    if (Enemy.enemies[sortedEnemies[i]].cantMove == 0)
                    {
                        enemyUnit.MoveAction(sortedEnemies[i]);
                    }
                }
            }
        }

        //ENEMIES PREPARE
        enemies.Clear();
        enemies = distance.GetEnemiesAroundPlayer(PlayerStat.stealthRange);

        if (enemies.Count == 0)
        {
            PlayerTurn();
        }
        else
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (Enemy.enemies[enemies[i]].cantAttack == 0)
                {
                    if (distance.GetDistanceToPlayer(enemies[i]) <= Enemy.enemies[enemies[i]].range)
                    {
                        enemyUnit.PrepareAction(enemies[i]);
                    }
                }
            }
            PlayerTurn();
        }
    }
}
