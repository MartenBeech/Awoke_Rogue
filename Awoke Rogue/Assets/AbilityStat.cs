using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityStat : MonoBehaviour
{
    public void UpdateStat(Artifact.Title title, int i)
    {
        switch (title)
        {
            case Artifact.Title.Crossbow:
                PlayerAttack.range[i] = 4;
                PlayerAttack.level[i] = 1;
                PlayerAttack.cooldown[i] = 0;
                PlayerAttack.powerMin[i] = 2;
                PlayerAttack.powerMax[i] = 5;
                PlayerAttack.target[i] = PlayerAttack.Target.Enemy;
                break;

            case Artifact.Title.BoneSword:
                PlayerAttack.range[i] = 1;
                PlayerAttack.level[i] = 1;
                PlayerAttack.cooldown[i] = 0;
                PlayerAttack.powerMin[i] = 3;
                PlayerAttack.powerMax[i] = 7;
                PlayerAttack.target[i] = PlayerAttack.Target.Enemy;
                break;

            case Artifact.Title.Fireball:
                PlayerAttack.range[i] = 4;
                PlayerAttack.level[i] = 1;
                PlayerAttack.cooldown[i] = 0;
                PlayerAttack.powerMin[i] = 2;
                PlayerAttack.powerMax[i] = 5;
                PlayerAttack.target[i] = PlayerAttack.Target.Enemy;
                break;

            case Artifact.Title.HeavyCannon:
                PlayerAttack.range[i] = 4;
                PlayerAttack.level[i] = 1;
                PlayerAttack.cooldown[i] = 9;
                PlayerAttack.powerMin[i] = 8;
                PlayerAttack.powerMax[i] = 11;
                PlayerAttack.powerSpecial[i] = 1;
                PlayerAttack.target[i] = PlayerAttack.Target.Enemy;
                break;

            case Artifact.Title.ExplosiveShot:
                PlayerAttack.range[i] = 4;
                PlayerAttack.level[i] = 1;
                PlayerAttack.cooldown[i] = 9;
                PlayerAttack.powerMin[i] = 8;
                PlayerAttack.powerMax[i] = 11;
                PlayerAttack.powerSpecial[i] = 3;
                PlayerAttack.target[i] = PlayerAttack.Target.Enemy;
                break;
        }
        PlayerAttack.cooldownMax[i] = PlayerAttack.cooldown[i];
    }
}
