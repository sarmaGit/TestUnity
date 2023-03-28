using System.Collections;
using System.Collections.Generic;
using Entity.Player;
using Move;
using Service;
using State;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerTravelPrefab;
    public EncounterGenerator encounterGenerator;
    public GameObject emptyEncounterPrefab;

    private GameObject _player;

    public void NewGame()
    {
        if (_player)
        {
            Destroy(_player);
        }

        encounterGenerator.Reset();
        List<GameObject> encounters = encounterGenerator.Generate();

        InitPlayer(encounters);
    }

    private void InitPlayer(List<GameObject> encounters)
    {
        GameObject encounter = encounters[Random.Range(0, encounterGenerator.GetCols() * 2 - 1)];
        Vector3 position = encounter.gameObject.transform.position;
        encounterGenerator.RemoveEncounter(encounter);

        GameObject encountersParent = FindObjectOfType<EncounterGenerator>().gameObject;
        GameObject emptyEncounter = Instantiate(emptyEncounterPrefab, encountersParent.transform, true);
        encounterGenerator.AddEncounter(emptyEncounter);
        emptyEncounter.transform.position = position;

        GameObject player = Instantiate(playerTravelPrefab,emptyEncounter.transform.position, Quaternion.identity,FindObjectOfType<TravelState>().transform);
        // player.transform.position = emptyEncounter.transform.position;
        _player = player;

        FindObjectOfType<CameraMove>().SetTarget(_player.transform);
        FindObjectOfType<MoveUp>().SetPlayerTransform(_player.transform);
        FindObjectOfType<MoveDown>().SetPlayerTransform(_player.transform);
        FindObjectOfType<MoveLeft>().SetPlayerTransform(_player.transform);
        FindObjectOfType<MoveRight>().SetPlayerTransform(_player.transform);
    }
}