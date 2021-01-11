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
        Crossbow, BoneSword, Fireball,
        HeavyCannon, ExplosiveShot
    };
    public static Title[] titles = new Title[Tile.SIZE];

    public enum Type
    {
        None, AbilityWeak, AbilityStrong, Helmet, Armor, Gauntlet
    };

    public void DropRandomArtifact(int tile)
    {
        List<Title> artifact = new List<Title>();
        artifact.Add(Title.ExplosiveShot);
        artifact.Add(Title.HeavyCannon);

        SummonArtifact(tile, artifact[rng.Range(0, artifact.Count)]);
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

        string description = "<b>" + _title + "</b>" + "\n";

        switch (title)
        {
            case Title.Crossbow:
                description += "Shoot an arrow at an enemy\n";
                break;
            case Title.BoneSword:
                description += "Slash down an enemy\n";
                break;
            case Title.Fireball:
                description += "Fire a ball at an enemy\n";
                break;
            case Title.HeavyCannon:
                description += "Fire a cannon ball to push the enemy " + PlayerAttack.powerSpecial[i] + " tiles back\n";
                break;
            case Title.ExplosiveShot:
                description += "Explode around an enemy, dealing double damage to enemies in a " + PlayerAttack.powerSpecial[i] + "x" + PlayerAttack.powerSpecial[i] + " area\n";
                break;
        }
        description += "Power: " + PlayerAttack.powerMin[i] + "-" + PlayerAttack.powerMax[i] + " damage\nRange: " + PlayerAttack.range[i];
        return description;
    }

    public Type GetArtifactType(Title title)
    {
        switch (title)
        {
            case Title.Crossbow:
            case Title.BoneSword:
            case Title.Fireball:
                return Type.AbilityWeak;

            case Title.HeavyCannon:
            case Title.ExplosiveShot:
                return Type.AbilityStrong;
        }
        return Type.None;
    }

    public void Destroy(int tile)
    {
        GameObject.Destroy(GameObject.Find(Artifact.titles[tile] + tile.ToString()));
        titles[tile] = Title.None;
    }
}
