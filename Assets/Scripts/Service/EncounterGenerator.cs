using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Service
{
    public class EncounterGenerator : MonoBehaviour
    {
        public GameObject battleEncounterPrefab;
        public GameObject healEncounterPrefab;
        public List<GameObject> _encountersVariants = new List<GameObject>();

        public int cols = 5;
        public int rows = 5;

        private List<GameObject> _encounters = new List<GameObject>();

        public List<GameObject> Generate()
        {
            if (_encountersVariants.Count == 0)
            {
                _encountersVariants.Add(battleEncounterPrefab);
                _encountersVariants.Add(healEncounterPrefab);
            }

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    GameObject randomEncounter = chooseEncounter();
                    GameObject encounter = Instantiate(randomEncounter, transform, true);
                    encounter.transform.position = new Vector3(x, y, 0);
                    _encounters.Add(encounter);
                    encounter.name += " " + _encounters.Count;
                }
            }

            return _encounters;
        }

        public GameObject chooseEncounter()
        {
            int length = _encountersVariants.Count;
            int seed = Random.Range(0, length);

            return _encountersVariants[seed];
        }

        public int GetCols()
        {
            return cols;
        }

        public void Reset()
        {
            foreach (GameObject encounter in _encounters)
            {
                Destroy(encounter);
            }

            _encounters.Clear();
        }

        public void RemoveEncounter(GameObject encounter)
        {
            _encounters.Remove(encounter);
            Destroy(encounter);
        }

        public void AddEncounter(GameObject encounter)
        {
            _encounters.Add(encounter);
        }
    }
}