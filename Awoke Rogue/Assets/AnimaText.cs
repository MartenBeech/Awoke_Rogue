using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaText : MonoBehaviour
{
    const int SIZE = 50;
    public GameObject prefab;
    private GameObject startSet;
    public static GameObject parent;
    private static int dealerSet;
    private float counter = 1f;
    public static int bufNmb = 0;
    private static GameObject[] bufPrefab = new GameObject[SIZE];
    private static GameObject[] bufPos = new GameObject[SIZE];
    private static string[] bufText = new string[SIZE];
    private static Color[] bufColor = new Color[SIZE];
    private static int[] bufDealer = new int[SIZE];
    private bool bufDecreased = false;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y);
    }
    void Update()
    {
        if (counter > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f);
            counter -= Time.deltaTime;

            if (counter <= 0.75 && !bufDecreased)
            {
                bufDecreased = true;

                for (int i = 0; i < bufNmb; i++)
                {
                    bufPrefab[i] = bufPrefab[i + 1];
                    bufPos[i] = bufPos[i + 1];
                    bufText[i] = bufText[i + 1];
                    bufColor[i] = bufColor[i + 1];
                    bufDealer[i] = bufDealer[i + 1];
                }
                bufNmb--;

                if (bufNmb > 0)
                {
                    bufPrefab[0].GetComponentInChildren<Text>().color = bufColor[0];
                    bufPrefab[0].GetComponentInChildren<Text>().text = bufText[0];

                    Instantiate(bufPrefab[0], bufPos[0].transform.position, new Quaternion(0, 0, 0, 0), GameObject.Find("Animation").transform);
                }
            }

            if (counter <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ShowText(int to, string text, Color textColor)
    {
        prefab = Resources.Load<GameObject>("Assets/FloatingText");
        parent = GameObject.Find("Animation");
        startSet = Tile.Tiles[to];
        prefab.GetComponentInChildren<Text>().color = textColor;
        prefab.GetComponentInChildren<Text>().text = text;

        if (bufNmb < SIZE - 1)
        {
            bufPos[bufNmb] = startSet;
            bufText[bufNmb] = prefab.GetComponentInChildren<Text>().text;
            bufColor[bufNmb] = prefab.GetComponentInChildren<Text>().color;
            bufPrefab[bufNmb] = prefab;
            bufDealer[bufNmb] = dealerSet;
            bufNmb++;
        }

        if (bufNmb == 1)
        {
            Instantiate(bufPrefab[0], bufPos[0].transform.position, new Quaternion(0, 0, 0, 0), parent.transform);
        }
        
    }
}
