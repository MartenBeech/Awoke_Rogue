using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Shop()
    {
        CameraMain.Cam.GetComponentInChildren<CameraFollow>().enabled = false;
        CameraMain.Cam.transform.position = new Vector3(CameraMain.Shop.transform.position.x, CameraMain.Shop.transform.position.y, -10);
        UI.EndBtn.GetComponentInChildren<Text>().text = "Enter Next Dungeon";
    }

    //Don't add more code to this file
}
