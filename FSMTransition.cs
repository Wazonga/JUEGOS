using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FSMTransition<T>
{
    public FSMTransition(Func<bool> isValid, Func<FSMstate<T>>getNextState){
        IsValid = isValid;
        GetNextState = getNextState;
    }
    public Func<bool> IsValid {private set; get;}

    public Func<FSMstate<T>> GetNextState {private set; get;}
}
