using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class SupportTools : MonoBehaviour
{
    /// <summary>
    /// 高亮
    /// </summary>
    /// <param name="obj">谁</param>
    /// <param name="wh">亮还是灭</param>
    public static void Highlight(GameObject obj, bool wh)
    {
        Highlighter hl = obj.GetComponent<Highlighter>();

        if (hl)
        {
            if (wh)
            {
                hl.FlashingOn();
            }
            else
            {
                hl.FlashingOff();
            }
        }
        else
        {
            //Debug.LogError("手动挂下highlighter脚本吧");

            if (wh)
            {
                Debug.Log("动态添加了highlighter脚本");
                hl = obj.AddComponent<Highlighter>();
                hl.FlashingOn();
            }
        }

    }

    public static void LightOn(GameObject obj, Color clr, bool wh)
    {
        Highlighter hl = obj.GetComponent<Highlighter>();

        if (hl)
        {
            if (wh)
            {
                hl.FlashingOn(clr, clr);
            }
            else
            {
                hl.FlashingOff();
            }
        }
        else
        {
            Debug.LogError("手动挂下highlighter脚本吧");
        }

    }

    public static void LightSeeThrough(GameObject obj, bool wh)
    {
        Highlighter hl = obj.GetComponent<Highlighter>();

        if (hl)
        {
            if (wh)
            {
                hl.SeeThroughOn();
            }
            else
            {
                hl.SeeThroughOff();
            }
        }
        else
        {
            Debug.LogError("手动挂下highlighter脚本吧");
        }

    }
}
