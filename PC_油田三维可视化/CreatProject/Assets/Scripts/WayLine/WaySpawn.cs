using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 路线生成器
/// </summary>
public class WaySpawn : MonoBehaviour
{
    public List<GameObject> lisGuidePost = new List<GameObject>();
    //计算所有路线
    private WayLine[] wayLines;//所有路线
    GameObject guidePost;//路标
    WayLine currentChioseWayLine;//当前选择路线
    private void Start()
    {
        guidePost = Resources.Load<GameObject>("Prefabs/路标");
        CalculateWayLines();
    }
    private void CalculateWayLines()
    {
        /*
         当前脚本附加到根路线中。
         子物体为路线(WayLine对象)
         孙子为路点(Vector3)
         */
        //1.创建路线数组
        wayLines = new WayLine[transform.childCount];

        for (int lineIndex = 0; lineIndex < wayLines.Length; lineIndex++)
        {
            Transform childTF = transform.GetChild(lineIndex);
            //2.创建路线
            wayLines[lineIndex] = new WayLine(childTF.childCount);
            //给路线一个名称
            wayLines[lineIndex].name_WayLine = childTF.name;
            for (int pointIndex = 0; pointIndex < childTF.childCount; pointIndex++)
            {//3.指定坐标
                Transform pos = childTF.GetChild(pointIndex);
                wayLines[lineIndex].SetPoint(pointIndex, pos);
            }
        }
    }

    //路线生成器
    public void SpawnWayLine(WayLine wayLine)
    {
        lisGuidePost.Clear();//清空路标
        //根据选择路线创建寻路路标
        for (int i = 0; i < wayLine.WayPoints.Length; i++)
        {
            if(guidePost)
            {
                GameObject go = GameObjectPool.Instance.CreateObject("路标" + i.ToString(), guidePost, wayLine.WayPoints[i].position, wayLine.WayPoints[i].rotation);
                lisGuidePost.Add(go);
            }
          
        }
    }
    /// <summary>
    /// 选择路径
    /// </summary>
    /// <param name="wayName"></param>
    /// <returns></returns>
    public WayLine ChoiseWayLine(string wayName)
    {
        for (int i = 0; i < wayLines.Length; i++)
        {
            if (wayLines[i].name_WayLine == wayName)
            {
                currentChioseWayLine = wayLines[i];
                return wayLines[i];

            }
        }
        Debug.Log("您所查找的路线不存在！");
        return null;
    }
}
