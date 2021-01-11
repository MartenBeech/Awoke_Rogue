using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEffect : MonoBehaviour
{
    public void UpdateStat(Skill.Title title)
    {
        string _title = title.ToString();
        for (int j = 1; j < _title.Length; j++)
        {
            if ((int)_title[j] >= 65 && (int)_title[j] <= 90) //Capital Letters
            {
                _title = _title.Insert(j, " ");
                j++;
            }
        }
        UI.Description.GetComponentInChildren<Text>().text = "<b>" + _title + "</b>" + "\n";

        switch (title)
        {
            case Skill.Title.HeavyCannon:
                UI.Description.GetComponentInChildren<Text>().text += "";
                break;

            case Skill.Title.ExplosiveShot:
                UI.Description.GetComponentInChildren<Text>().text += "";
                break;

            default:
                UI.Description.GetComponentInChildren<Text>().text = "NOT IMPLEMENTED";
                break;
        }
    }
}
