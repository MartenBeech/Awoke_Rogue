using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Shop()
    {
        Camera.Cam.GetComponentInChildren<CameraFollow>().enabled = false;
        Camera.Cam.transform.position = new Vector3(Camera.Shop.transform.position.x, Camera.Shop.transform.position.y, -10);
        UI.EndBtn.GetComponentInChildren<Text>().text = "Enter Next Dungeon";
    }
}
