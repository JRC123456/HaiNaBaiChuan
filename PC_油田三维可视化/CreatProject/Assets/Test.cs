using GYFZ.Actor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public ActorSystym actorAI;
    public void Start()
    {
        actorAI = FindObjectOfType<ActorSystym>();
    }
    public void Bengan()
    {
        //开始寻路
        actorAI.DoPathfinding("Way1");
    }

}
