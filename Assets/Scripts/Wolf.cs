using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] string color;
    [SerializeField] int attack;
    [SerializeField] int speed;

    private List<Dictionary<string, object>> csv;

    private void Awake()
    {
        csv = CSVReader.Read("CSV/WolfDataBase");

        color = (string)csv[id]["Color"];
        attack = (int)csv[id]["Attack"];
        speed = (int)csv[id]["Speed"];
    }
}
