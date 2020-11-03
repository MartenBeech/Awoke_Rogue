﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static GameObject TurnEnd;
    public static GameObject Description;
    public static GameObject HealthBar;
    public static GameObject RageBar;

    private void Start()
    {
        TurnEnd = GameObject.Find("TurnEnd");
        Description = GameObject.Find("Description");
        HealthBar = GameObject.Find("HealthBar");
        RageBar = GameObject.Find("RageBar");
    }

    public void EndTurn()
    {
        PlayerMovement movement = new PlayerMovement();
        movement.MovePlayer(PlayerMovement.tilePos, PlayerMovement.tilePos, 0.01f);
    }
}
