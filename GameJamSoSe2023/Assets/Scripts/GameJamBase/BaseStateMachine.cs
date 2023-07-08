using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    [SerializeField] public BaseState CurrentState { get; protected set; }
    // For Debuging
    public string currentStateName;

    private void Start()
    {
        Initialize();

    }

    private void Update()
    {
        CurrentState?.OnUpdateState(this);
        currentStateName = CurrentState.GetType().ToString();
        Tick();
    }

    public void SwitchToState(BaseState nextState)
    {
        CurrentState?.OnExitState(this);
        CurrentState = nextState;
        CurrentState.OnEnterState(this);
    }

    public abstract void Initialize();
    public abstract void Tick();
}
