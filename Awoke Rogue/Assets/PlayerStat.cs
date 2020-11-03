using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public static int scoutRange = 5;
    public static int stealthRange = 5;
    public static int healthMax = 100;
    public static int health = healthMax;
    public static int rageMax = 100;
    public static int rage = rageMax;
    public static int rageConsume = 50;

    public static bool keyObtained;
    public static bool bossKilled;

    public void ResetStats()
    {
        health = healthMax;
        rage = 0;

        UnitStat unitStat = new UnitStat();
        unitStat.DisplayStats(PlayerMovement.tilePos);

        keyObtained = false;
        bossKilled = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health > healthMax)
        {
            health = healthMax;
        }

        AnimaText animaText = new AnimaText();
        if (damage > 0)
        {
            animaText.ShowText(PlayerMovement.tilePos, damage.ToString(), Color.red);
        }
        else if (damage < 0)
        {
            animaText.ShowText(PlayerMovement.tilePos, damage.ToString(), Color.green);
        }
        else
        {
            animaText.ShowText(PlayerMovement.tilePos, damage.ToString(), Color.gray);
        }

        UnitStat unitStat = new UnitStat();
        unitStat.DisplayStats(PlayerMovement.tilePos);
    }

    public void GainRage(int amount)
    {
        if (amount > rageMax - rage)
        {
            amount = rageMax - rage;
        }
        if (amount > 0)
        {
            rage += amount;
        }

        UnitStat unitStat = new UnitStat();
        unitStat.DisplayStats(PlayerMovement.tilePos);
    }

    public bool ConsumeRage()
    {
        if (rage >= rageConsume)
        {
            rage -= rageConsume;
            UnitStat unitStat = new UnitStat();
            unitStat.DisplayStats(PlayerMovement.tilePos);
            return true;
        }
        return false;
    }
}
