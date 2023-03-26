using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace State
{
    public class StateMachine : MonoBehaviour
    {
        public string _currentState;
        public string _previousState;

        private Dictionary<string, GameObject> _states = new Dictionary<string, GameObject>();

        public UnityEvent onInitState;
        public UnityEvent onMenuState;
        public UnityEvent onEncounterState;
        public UnityEvent onTravelState;
        public UnityEvent onLoadState;

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

            GameObject previousStateGameObject = _states[_previousState];
            previousStateGameObject.SetActive(false);
            
            GameObject currentStateGameObject = _states[_currentState];
            currentStateGameObject.SetActive(true);

            Debug.Log("Set state, current " + _currentState + ", previous " + _previousState);

            // DispatchStateEvent(name);
        }

        private void Reset()
        {
            foreach (var state in _states)
            {
                state.Value.SetActive(false);
            }
        }

        public string GetPreviousState()
        {
            return _previousState;
        }

        public string GetCurrentState()
        {
            return _currentState;
        }

        private void DispatchStateEvent(string name)
        {
            switch (name)
            {
                case InitState.NAME:
                    onInitState.Invoke();
                    break;
                case MenuState.NAME:
                    onMenuState.Invoke();
                    break;
                case LoadState.NAME:
                    onLoadState.Invoke();
                    break;
                case TravelState.NAME:
                    onTravelState.Invoke();
                    break;
                case EncounterState.NAME:
                    onEncounterState.Invoke();
                    break;
                default: throw new Exception("Unknown state " + name);
            }
        }
    }
}