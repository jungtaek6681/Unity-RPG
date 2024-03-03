using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public int intValue;
    public float floatValue;
    public Vector3 vec3Value;

    public GameObject gameObject;

    public GameData()
    {
        intValue = 0;
        floatValue = 0;
        vec3Value = new Vector3();

        gameObject = null;
    }
}
