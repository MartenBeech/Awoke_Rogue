using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = player.transform.position + offset;

        if (Input.mouseScrollDelta.y > 0)
        {
            if (CameraMain.Cam.GetComponentInChildren<Camera>().orthographicSize > 10)
            {
                CameraMain.Cam.GetComponentInChildren<Camera>().orthographicSize /= 1.1f;
            }
        }

        else if (Input.mouseScrollDelta.y < 0)
        {
            if (CameraMain.Cam.GetComponentInChildren<Camera>().orthographicSize < 100)
            {
                CameraMain.Cam.GetComponentInChildren<Camera>().orthographicSize *= 1.1f;
            }
        }
    }
}
