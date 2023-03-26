using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public class EncounterGenerator : MonoBehaviour
    {
        public GameObject encounterPrefab;

        public int cols = 5;
        public int rows = 5;

        private List<GameObject> _encounters = new List<GameObject>();

        public List<GameObject> Generate()
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    GameObject encounter = Instantiate(encounterPrefab, transform, true);
                    encounter.transform.position = new Vector3(x, y, 0);
                    _encounters.Add(encounter);
                    encounter.name += " " + _encounters.Count;
                }
            }

            return _encounters;
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
    }
}