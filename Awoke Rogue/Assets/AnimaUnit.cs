﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimaUnit : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    public float counter = 0f;
    void Update()
    {
        if (counter > 0)
        {
            Vector3 dir = endPoint.transform.position - startPoint.transform.position;
            float dist = Mathf.Sqrt(
                Mathf.Pow(endPoint.transform.position.x - startPoint.transform.position.x, 2) +
                Mathf.Pow(endPoint.transform.position.y - startPoint.transform.position.y, 2));
            this.transform.Translate(dir.normalized * dist * (Time.deltaTime) * 10);
            counter -= Time.deltaTime;
        }

        else if (counter <= 0)
        {
            this.transform.position = new Vector3(endPoint.transform.position.x, endPoint.transform.position.y, -0.01f);
        }
    }
}
