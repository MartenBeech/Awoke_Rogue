using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGameClicked()
    {
        Level level = new Level();
        level.NewLevel();
        

        AbilityEffect ability = new AbilityEffect();
        ability.GainArtifact(Artifact.Title.Crossbow);
    }
}
