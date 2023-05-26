using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ConvoManager : MonoBehaviour
{
    public static ConvoManager Instance {private set; get;}
    public event UnityAction<Interaction> OnConvoStart;
    public event UnityAction<Interaction> OnConvoNext;
    public event UnityAction OnConvoStop;
    private int mInteracionIndex = 0;
    private Convo mActiveConvo = null;

private void Awake(){
    Instance = this;
}

public void StartConvo (Convo convo)
{
    mActiveConvo = convo;
    OnConvoStart?.Invoke(convo.Convos[mInteracionIndex]);
    mInteracionIndex++;
}

public void NextConvo ()
{
    if(mInteracionIndex < mActiveConvo.Convos.Count)
    {
    OnConvoNext?.Invoke(mActiveConvo.Convos[mInteracionIndex]);
    mInteracionIndex++;
    }
    else{
        StopConvo();
    }
}

public void StopConvo ()
{
    mActiveConvo = null;
    mInteracionIndex = 0;
    OnConvoStop?.Invoke();
}



}
