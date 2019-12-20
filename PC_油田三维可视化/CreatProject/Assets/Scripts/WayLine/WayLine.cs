using UnityEngine;
using System.Collections;

/// <summary>
/// 路线：包装2个基本类型
/// </summary>
public class WayLine 
{
    public string name_WayLine;

    /// <summary>
    /// 路点
    /// </summary>
    public Transform[] WayPoints { get; set; }

    /// <summary>
    /// 是否可用
    /// </summary>
    public bool IsUsable { get; set; }

    public WayLine(int pointCount)
    {
        IsUsable = true;
        WayPoints = new Transform[pointCount];
    }

    public void SetPoint(int index,Transform point)
    {
        WayPoints[index] = point;
    }

 
}
