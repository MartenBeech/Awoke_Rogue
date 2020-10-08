using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaText : MonoBehaviour
{
    public GameObject prefab;
    private GameObject startSet;
    public static GameObject parent;
    private static int dealerSet;
    private float counter = 1f;
    private static int bufSize = 0;
    private static GameObject[] bufPrefab = new GameObject[50];
    private static GameObject[] bufPos = new GameObject[50];
    private static string[] bufText = new string[50];
    private static Color[] bufColor = new Color[50];
    private static int[] bufDealer = new int[50];
    private bool bufDecreased = false;

    private void Awake()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y);
    }
    void Update()
    {
        if (counter > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.005f);
            counter -= Time.deltaTime;

            if (counter <= 0.5 && !bufDecreased)
            {
                bufDecreased = true;
                
                for (int i = 0; i < bufSize; i++)
                {
                    bufPrefab[i] = bufPrefab[i + 1];
                    bufPos[i] = bufPos[i + 1];
                    bufText[i] = bufText[i + 1];
                    bufColor[i] = bufColor[i + 1];
                    bufDealer[i] = bufDealer[i + 1];
                }
                bufSize--;

                if (bufSize > 0)
                {
                    bufPrefab[0].GetComponentInChildren<Text>().color = bufColor[0];
                    bufPrefab[0].GetComponentInChildren<Text>().text = bufText[0];

                    Instantiate(bufPrefab[0], bufPos[0].transform.position, bufPos[0].transform.rotation, GameObject.Find("Animation").transform);
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

        bufPos[bufSize] = startSet;
        bufText[bufSize] = prefab.GetComponentInChildren<Text>().text;
        bufColor[bufSize] = prefab.GetComponentInChildren<Text>().color;
        bufPrefab[bufSize] = prefab;
        bufDealer[bufSize] = dealerSet;

        if (bufSize == 0)
        {
            Instantiate(bufPrefab[0], bufPos[0].transform.position, bufPos[0].transform.rotation, parent.transform);
        }
        bufSize++;
    }
}
