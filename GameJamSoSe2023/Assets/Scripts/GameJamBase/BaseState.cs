using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseState 
{
    public virtual void OnEnterState(BaseStateMachine bsm)
    { 
    
    }

    public abstract void OnUpdateState(BaseStateMachine bsm);

    public virtual void OnExitState(BaseStateMachine bsm)
    {

    }
}
