using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    public FSMstate<T> InitialState;
    public FSMstate<T> CurrentState;

    public FSM(FSMstate<T> initialState){
        InitialState = initialState;
    }

    public void Begin(){
        CurrentState = InitialState;
        CurrentState.OnEnter();
    }

    public void Tick(float deltaTime){
        foreach( var transition in CurrentState.Transitions)
        {
            if(transition.IsValid()){
                CurrentState.OnExit();
                CurrentState = transition.GetNextState();
                CurrentState.OnEnter();
                break;
            }
        }
        CurrentState.OnUpdate(Time.deltaTime);
    }
}