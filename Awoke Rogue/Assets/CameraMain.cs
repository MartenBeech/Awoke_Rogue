using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMain : MonoBehaviour
{
    public static GameObject Cam;
    public static GameObject Dungeon;
    public static GameObject Shop;

    private void Start()
    {
        Cam = GameObject.Find("Main Camera");
        Dungeon = GameObject.Find("CanvasDungeon");
        Shop = GameObject.Find("CanvasShop");
    }
}
