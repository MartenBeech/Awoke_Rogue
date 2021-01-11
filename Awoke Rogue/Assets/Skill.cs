using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public enum Title
    {
        HeavyCannon, ExplosiveShot
    }
    public void ButtonHovered(string title)
    {
        if (title.Length > 0)
        {
            Title parsed_enum = (Title)System.Enum.Parse(typeof(Title), title);
            ButtonHovered(parsed_enum);
        }
        else
        {
            UI.Description.GetComponentInChildren<Text>().text = "NOT IMPLEMENTED";
        }
    }

    public void ButtonHovered(Title title)
    {
        SkillEffect skillEffect = new SkillEffect();
        skillEffect.UpdateStat(title);
    }

    public void ButtonUnhovered()
    {
        UI.Description.GetComponentInChildren<Text>().text = "";
    }

    public void ButtonClicked(string title)
    {

    }
}
