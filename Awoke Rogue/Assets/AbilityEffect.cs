using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityEffect : MonoBehaviour
{
    public void UseAbility(int i, int tile)
    {
        PlayerAttack attack = new PlayerAttack();
        switch (PlayerAttack.title[i])
        {
            case "Crossbow":
                attack.DamageEnemy(PlayerAttack.power[i], tile);
                break;

            case "Piercing Shot":

                break;

            case "Explosive Shot":

                break;
        }
    }

    public void GainAbility(string title)
    {
        int i = 6;
        for (int j = 0; j < PlayerAttack.SIZE; j++)
        {
            if (!PlayerAttack.occupied[j])
            {
                i = j;
                break;
            }
        }

        if (i < 6)
        {
            PlayerAttack.title[i] = title;
            PlayerAttack.occupied[i] = true;

            switch (title)
            {
                case "Crossbow":
                    PlayerAttack.description[i] = "Shoot an arrow at an enemy";
                    PlayerAttack.range[i] = 4;
                    PlayerAttack.level[i] = 1;
                    PlayerAttack.cooldown[i] = 0;
                    PlayerAttack.power[i] = 4;
                    PlayerAttack.target[i] = PlayerAttack.Target.Enemy;
                    PlayerAttack.Abilities[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Abilities/Crossbow");
                    break;
            }
            PlayerAttack.cooldownMax[i] = PlayerAttack.cooldown[i];

            PlayerAttack attack = new PlayerAttack();
            attack.DisplayAbility(i);
        }
    }
}
