using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 技能基础类 2018/5/10 JN
/// </summary>
public class BehaviorOfParent : MonoBehaviour
{
    /// <summary>
    /// 技能准备开始时
    /// </summary>
    /// <param name="parameter">参数</param>
    public virtual void OnPre(string parameter, Action action)
    {

    }

    /// <summary>
    /// 技能执行时
    /// </summary>
    /// <param name="parameter">参数</param>
    public virtual void OnAction(string parameter, Action action)
    {

    }
   
    /// <summary>
    /// 技能结束时
    /// </summary>
    /// <param name="parameter">参数</param>
    public virtual void OnEnd(string parameter, Action action)
    {
        if (action != null)
            action();
    }
}
