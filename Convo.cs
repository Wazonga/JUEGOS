using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Interaction 
{
    public Sprite CharImage;
    public string CharName;
    public string CharText;
}

public class Convo : MonoBehaviour
{
public List<Interaction> Convos;

}
