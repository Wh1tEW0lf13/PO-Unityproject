using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform baseObject;
    public Transform shipObject;
    private object namer;
    void Start()
    {
        Instantiate(shipObject).name = "Ship";
        Instantiate(baseObject).name = "Base";
    }

}