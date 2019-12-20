using GYFZ.Actor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ActorAI), typeof(ActorAnimation))]
/// <summary>
/// 操作者外观类
/// </summary>
public class ActorSystym : MonoBehaviour
{
    ActorAI actorAI;
    WaySpawn waySpawn;
    ActorAnimation anim;

    public void Start()
    {
        actorAI = GetComponent<ActorAI>();
        waySpawn = FindObjectOfType<WaySpawn>();
        anim = GetComponent<ActorAnimation>();
    }

    public void DoPathfinding(string wayName, float speed = 5)
    {
        if (speed > 0 && speed <= 5)
            anim.PlayAnimation(anim.walk);
        else if (speed > 5)
            anim.PlayAnimation(anim.run);
        DoPathCommon(wayName);
    }
    void DoPathCommon(string wayName)
    {
        //查找路线
        WayLine line = waySpawn.ChoiseWayLine(wayName);

        if (line != null)
        {
            //生成路线
            waySpawn.SpawnWayLine(line);
            //更改当前玩家状态
            actorAI.state = ActorState.Pathfinding;
            actorAI.motor.targetWayLine = line;
        }
    }
}
