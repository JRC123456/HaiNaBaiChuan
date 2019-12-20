using UnityEngine;
using System.Collections;
namespace GYFZ.Actor
{
    /// <summary>
    /// 人物状态
    /// </summary>
    public enum ActorState
    {
        Phone,//打电话
        Pathfinding,//寻路
        UseTheTools,//使用工具
        Idle,//闲置
        ClothingEquipment,//穿装备
    }
}