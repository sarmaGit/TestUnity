using System.Collections;
using System.Collections.Generic;
using Service;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public EncounterGenerator encounterGenerator;
    public GameObject emptyEncounterPrefab;

    public void NewGame()
    {
        encounterGenerator.Reset();
        List<GameObject> encounters = encounterGenerator.Generate();
        SetPlayerPosition(encounters);
    }

    private void SetPlayerPosition(List<GameObject> encounters)
    {
        GameObject encounter = encounters[Random.Range(0, encounterGenerator.GetCols() * 2 - 1)];
        Vector3 position = encounter.gameObject.transform.position;
        encounterGenerator.RemoveEncounter(encounter);

        GameObject parent = FindObjectOfType<EncounterGenerator>().gameObject;
        GameObject emptyEncounter = Instantiate(emptyEncounterPrefab, parent.transform, true); //todo mb add to list
        emptyEncounter.transform.position = position;

        player.transform.position = emptyEncounter.transform.position;
    }
}