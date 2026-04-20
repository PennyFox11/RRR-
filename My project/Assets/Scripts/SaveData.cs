//Title: EASY Save System for Your Game - Top Down Unity 2D #7
//Author: Game Code Library
//Date: 11 September 2024
//Code Version: Unity 2022.3.20f1 LTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public Vector3 playerPosition;
    public string mapBoundary; //The boundary name for the map
}
