using System;
using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private StateMachine _stateMachine;

    public void Start()
    {
        _stateMachine = FindObjectOfType<StateMachine>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_stateMachine.GetCurrentState() == MenuState.NAME)
            {
                _stateMachine.SetState(_stateMachine.GetPreviousState());
            }
            else
            {
                _stateMachine.SetState(MenuState.NAME);
            }
        }
    }
}