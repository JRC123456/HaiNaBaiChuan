using UnityEngine;
using System.Collections;

/// <summary>
/// 摄像机跟随物体运动
/// </summary>
public class CameraFollow : MonoBehaviour 
{
    [Tooltip("需要跟随的目标物体变换组件")]
    public Transform targetTF;
    public float smooth = 10;

    private Vector3 relativePosition;
    private void Start()
    {
        relativePosition = transform.position - targetTF.position;
    }
  
    private void Update()
    {
        //transform.position = targetTF.position + relativePosition;
        //平滑跟随
        transform.position =Vector3.Lerp(transform.position, targetTF.position + relativePosition,Time.deltaTime * smooth);
    } 
}
