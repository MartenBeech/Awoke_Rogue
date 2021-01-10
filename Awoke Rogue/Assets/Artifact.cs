using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{
    Rng rng = new Rng();
    public enum Title
    {
        None,
        Crossbow, BoneSword, Fireball
    };
    public static Title[] titles = new Title[Tile.SIZE];

    public enum Type
    {
        None, AbilityWeak, AbilityStrong, Helmet, Armor, Gauntlet
    };

    public void DropRandomArtifact(int tile)
    {
        int rnd = rng.Range(0, 3);
        if (rnd == 0)
            SummonArtifact(tile, Title.Crossbow);
        else if (rnd == 1)
            SummonArtifact(tile, Title.BoneSword);
        else if (rnd == 2)
            SummonArtifact(tile, Title.Fireball);

    }

    public void DropHelmet(int tile)
    {

    }

    public void DropArmor(int tile)
    {

    }

    public void DropGauntlet(int tile)
    {

    }

    public void SummonArtifact(int tile, Title title)
    {
        titles[tile] = title;
        GameObject prefab = Resources.Load<GameObject>("Assets/Artifact");
        GameObject parent = GameObject.Find("Artifacts");
        prefab = Instantiate(prefab, Tile.Tiles[tile].transform.position, new Quaternion(0, 0, 0, 0), parent.transform);
        prefab.name = title.ToString() + tile;
        prefab.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Artifacts/" + title.ToString());
        prefab.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(50, 50);

        switch (title)
        {
            case Title.Crossbow:
                
                break;
        }
    }

    public string GetDescription(Title title, int i)
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

        switch (title)
        {
            case Title.Crossbow:
                return _title + "\n" + "Shoot an arrow at an enemy\nPower: " + PlayerAttack.powerMin[i] + "-" + PlayerAttack.powerMax[i] + " damage\nRange: " + PlayerAttack.range[i];
            case Title.BoneSword:
                return _title + "\n" + "Slash down an enemy\nPower: " + PlayerAttack.powerMin[i] + "-" + PlayerAttack.powerMax[i] + " damage\nRange: " + PlayerAttack.range[i];
            case Title.Fireball:
                return _title + "\n" + "Fire a ball at an enemy\nPower: " + PlayerAttack.powerMin[i] + "-" + PlayerAttack.powerMax[i] + " damage\nRange: " + PlayerAttack.range[i];
        }
        return "";
    }

    public Type GetArtifactType(Title title)
    {
        switch (title)
        {
            case Title.Crossbow:
            case Title.BoneSword:
            case Title.Fireball:
                return Type.AbilityWeak;
        }
        return Type.None;
    }

    public void Destroy(int tile)
    {
        GameObject.Destroy(GameObject.Find(Artifact.titles[tile] + tile.ToString()));
        titles[tile] = Title.None;
    }
}
