using System;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class StateMachine : MonoBehaviour
    {
        private string _currentState;
        private string _previousState;

        private Dictionary<string, GameObject> _states = new Dictionary<string, GameObject>();

        public GameObject test;

        public void Start()
        {
            GameObject initStateGameObject = FindObjectOfType<InitState>().gameObject;
            _states.Add(InitState.NAME, initStateGameObject);
            GameObject loadStateGameObject = FindObjectOfType<LoadState>().gameObject;
            _states.Add(LoadState.NAME, loadStateGameObject);
            GameObject menuStateGameObject = FindObjectOfType<MenuState>().gameObject;
            _states.Add(MenuState.NAME, menuStateGameObject);
            GameObject travelStateGameObject = FindObjectOfType<TravelState>().gameObject;
            _states.Add(TravelState.NAME, travelStateGameObject);
            GameObject encounterStateGameObject = FindObjectOfType<EncounterState>().gameObject;
            _states.Add(EncounterState.NAME, encounterStateGameObject);

            _currentState = InitState.NAME;
            _previousState = InitState.NAME;

            Reset();
            SetState(MenuState.NAME);
        }


        public void SetState(string name)
        {
            _previousState = _currentState;
            _currentState = name;

            GameObject stateGameObject = _states[_currentState];
            stateGameObject.SetActive(true);

            foreach (var state in _states)
            {
                if (_currentState == state.Key)
                {
                    continue;
                }

                state.Value.SetActive(false);
            }
        }

        private void Reset()
        {
            foreach (var state in _states)
            {
                state.Value.SetActive(false);
            }
        }
    }
}