using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGameClicked(string title)
    {
        Level level = new Level();
        level.NewLevel();

        AbilityEffect ability = new AbilityEffect();

        switch(title)
        {
            case "Archer":
                ability.GainArtifact(Artifact.Title.Crossbow);
                break;

            case "Undead":
                ability.GainArtifact(Artifact.Title.BoneSword);
                break;

            case "Mage":
                ability.GainArtifact(Artifact.Title.Fireball);
                break;
        }
        
    }
}
