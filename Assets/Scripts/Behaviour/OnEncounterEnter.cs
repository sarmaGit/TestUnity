using System;
using Entity.Player;
using State;
using UnityEngine;

namespace Behaviour
{
    public class OnEncounterEnter : MonoBehaviour
    {
        private StateMachine _stateMachine;

        public void Start()
        {
            _stateMachine = FindObjectOfType<StateMachine>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!IsPlayer(other))
            {
                return;
            }

            _stateMachine.SetState(EncounterState.NAME);
        }

        private bool IsPlayer(Collider other)
        {
            if (!other.GetComponent<PlayerTravelState>())
            {
                return false;
            }

            return true;
        }
    }
}