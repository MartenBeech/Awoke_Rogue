using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityEffect : MonoBehaviour
{
    public void UseAbility(int i, int tile)
    {
        Rng rng = new Rng();
        PlayerAttack attack = new PlayerAttack();
        PlayerStat stat = new PlayerStat();
        switch (PlayerAttack.title[i])
        {
            case Artifact.Title.Crossbow:
                attack.DamageEnemy(rng.Range(PlayerAttack.powerMin[i], PlayerAttack.powerMax[i]), tile);
                stat.GainRage(rng.Range(4, 11));
                break;

            case Artifact.Title.BoneSword:
                attack.DamageEnemy(rng.Range(PlayerAttack.powerMin[i], PlayerAttack.powerMax[i]), tile);
                stat.GainRage(rng.Range(6, 15));
                break;

            case Artifact.Title.Fireball:
                attack.DamageEnemy(rng.Range(PlayerAttack.powerMin[i], PlayerAttack.powerMax[i]), tile);
                stat.GainRage(rng.Range(4, 11));
                break;

            case Artifact.Title.HeavyCannon:
                if (stat.ConsumeRage())
                {
                    attack.DamageEnemy(rng.Range(PlayerAttack.powerMin[i] * 2, PlayerAttack.powerMax[i] * 2), tile);
                }
                else
                {
                    attack.DamageEnemy(rng.Range(PlayerAttack.powerMin[i], PlayerAttack.powerMax[i]), tile);
                }
                break;
        }
    }

    public void GainArtifact(Artifact.Title title)
    {
        Artifact artifact = new Artifact();
        Artifact.Type type = artifact.GetArtifactType(title);
        int i = 6;

        if (type == Artifact.Type.AbilityWeak)
        {
            i = 0;
            if (PlayerAttack.occupied[0])
            {
                artifact.SummonArtifact(PlayerMovement.tilePos, PlayerAttack.title[0]);
            }
        }

        else if (type == Artifact.Type.AbilityStrong)
        {
            i = 1;
            if (PlayerAttack.occupied[1])
            {
                i = 2;
                if (PlayerAttack.occupied[2])
                {
                    i = 1;
                    artifact.SummonArtifact(PlayerMovement.tilePos, PlayerAttack.title[1]);
                }
            }
        }

        else if (type == Artifact.Type.Helmet)
        {
            i = 3;
            if (PlayerAttack.occupied[3])
            {
                artifact.SummonArtifact(PlayerMovement.tilePos, PlayerAttack.title[3]);
            }
        }

        else if (type == Artifact.Type.Armor)
        {
            i = 4;
            if (PlayerAttack.occupied[4])
            {
                artifact.SummonArtifact(PlayerMovement.tilePos, PlayerAttack.title[4]);
            }
        }

        else if (type == Artifact.Type.Gauntlet)
        {
            i = 5;
            if (PlayerAttack.occupied[5])
            {
                artifact.SummonArtifact(PlayerMovement.tilePos, PlayerAttack.title[5]);
            }
        }


        if (i < 6)
        {
            PlayerAttack.title[i] = title;
            PlayerAttack.Abilities[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Artifacts/" + title.ToString());
            PlayerAttack.occupied[i] = true;
            PlayerAttack.description[i] = artifact.GetDescription(title, i);

            AbilityStat abilityStat = new AbilityStat();
            abilityStat.UpdateStat(title, i);

            PlayerAttack attack = new PlayerAttack();
            attack.DisplayAbility(i);
        }
    }
}
