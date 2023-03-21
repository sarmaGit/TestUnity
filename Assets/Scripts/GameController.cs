using System.Collections;
using System.Collections.Generic;
using Service;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public EncounterGenerator encounterGenerator;

    void Start()
    {
        List<GameObject> encounters = encounterGenerator.Generate();
        GameObject encounter = encounters[Random.Range(0, encounterGenerator.GetCols() * 2 - 1)];
        player.transform.position = encounter.transform.position;
    }
}