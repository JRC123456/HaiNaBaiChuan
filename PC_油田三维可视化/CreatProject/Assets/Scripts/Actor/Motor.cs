using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Motor : BehaviorOfParent
{

    GameObject PlayerObj;//对应使用技能人物对象
    Action _action;//临时存储 下一个action
    bool Destination = false;//距离检测
    string _state;//存储 状态
    Vector3 targetPos;//目标点                 
    float currentMoveSpeed = 5; // 移动速度
    [HideInInspector]
    public WayLine targetWayLine;//包含坐标数组，是否可用
    private int wayIndex = 0;//当前路线执行位置

    public void Start()
    {
        PlayerObj = gameObject;     
    }  
    //寻路
    public bool Pathfinding()
    {//true 表示到达终点            false  没有到达终点 
        //注意：异常
        if (wayIndex > targetWayLine.WayPoints.Length - 1)
        {
            return true;
        }
        //注视目标点旋转
        LookRotation(targetWayLine.WayPoints[wayIndex].position);
        //向前移动
        MoveForward();

        //注意：判断位置是否相同，建议使用间距。
        if (Vector3.Distance(transform.position, targetWayLine.WayPoints[wayIndex].position) < 0.1f)
        {
            //将下一个路点设置为目标点
            wayIndex++;
        }
        return false;
    }

    /// <summary>
    /// 技能准备开始时
    /// </summary>
    public override void OnPre(string parameter, Action action)
    {
        //"walk,61.077/0.069/13.58";
        base.OnPre("", action);
    }

    /// <summary>
    /// 技能执行时
    /// </summary>
    public override void OnAction(string parameter, Action action)
    {
        base.OnAction("", action);

    }

    /// <summary>
    /// 技能结束时
    /// </summary>
    public override void OnEnd(string parameter, Action action)
    {
        
        Destination = true;
    }

    /// <summary>
    /// 设置移动速速
    /// </summary>
    /// <param name="speed"></param>
    public void SetSpeed(float speed)
    {
        currentMoveSpeed = speed;
     
    }

    //向前移动
    public void MoveForward()
    {// 
        transform.Translate(0, 0, Time.deltaTime * currentMoveSpeed);
    }

    //注视旋转
    public void LookRotation(Vector3 position)
    {
        transform.LookAt(position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

}
