using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public static int abilitySelected;
    public static string[] title = new string[4];
    public static int[] range = new int[4];
    public static int[] level = new int[4];
    public static int[] cooldown = new int[4];
    public static int[] power = new int[4];
    public enum Target { Self, Enemy, Ground};
    public static Target[] target = new Target[4];


    public void UseAbility(int i, int tile)
    {
        switch(title[i])
        {
            case "Crossbow":
                DamageEnemy(power[i], tile);
                break;

            case "Piercing Shot":

                break;

            case "Explosive Shot":

                break;
        }
    }
    public void DamageEnemy(int damage, int tile)
    {
        Rng rng = new Rng();
        damage = rng.Range(Mathf.FloorToInt(damage * 0.5f), Mathf.FloorToInt(damage * 1.5f) + 1);
        Enemy.enemies[tile].health -= damage;
        UnitStat unitStat = new UnitStat();
        unitStat.DisplayStats(PlayerMovement.tilePos);
        unitStat.DisplayStats(tile);
        AnimaText animaText = new AnimaText();
        animaText.ShowText(PlayerMovement.tilePos, damage.ToString(), Color.red);
    }
}
