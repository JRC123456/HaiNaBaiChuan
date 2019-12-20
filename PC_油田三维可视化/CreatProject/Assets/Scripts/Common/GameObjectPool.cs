using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

/// <summary>
/// 游戏对象池：缓存,缓存容器（缓存游戏对象）
/// </summary>
public class GameObjectPool:MonoSingleton<GameObjectPool>
{
    //1
    private GameObjectPool() { }
    //1 创建池：
    Dictionary<string, List<GameObject>> cache =
    new Dictionary<string, List<GameObject>>();

    //2 创建一个游戏对象并使用游戏对象:
    //  池中有从池中返回;池中没有加载，放入池中再返回
    //  pool.CreateObject(子弹, 子弹预制件，pos,rotation);
    public GameObject CreateObject(string key,GameObject go,
        Vector3 position, Quaternion quaternion)
    {
        //池中有从池中返回;池中没有加载，放入池中再返回  

        //1从池中找 可用物体
        GameObject goTemp =FindUsable(key);
        //2 池中有从池中返回
        if (goTemp != null)
        {
            goTemp.transform.position = position;
            goTemp.transform.rotation = quaternion;
            goTemp.SetActive(true);//
        }
        else
        {
            //池中没有[加载],动态实例化，放入池中再返回
            goTemp = Instantiate(go, position, quaternion) as GameObject;
            Add(key, goTemp);        
        }
        //为了层次面板 可维护，清晰
        goTemp.transform.parent = this.transform;
        return goTemp;
    }
    //从池中找 可用物体
    private GameObject FindUsable(string key)
    {
        //1>2>
        if (cache.ContainsKey(key))
        {            
            return cache[key].Find(a => !a.activeSelf);
        }
        return null;           
    }
    private void Add(string key, GameObject goTemp)
    { 
        //1检查key 有没有，没有创建 键值对
        if (!cache.ContainsKey(key))
        {
            cache.Add(key, new List<GameObject>());
        }
        //2放入对象到相应的列表
        cache[key].Add(goTemp);    
    }
    //3 释放资源：从池中删除对象！
    //3.1释放部分：按Key释放
    public void Clear(string key)
    {
        if (cache.ContainsKey(key))
        {
            //1把游戏对象从场景中销毁 unity 
            for(int i=0;i<cache[key].Count;i++)
            { 
                Destroy(cache[key][i]);
            }
            //2移除了key对应的游戏对象的 地址
            cache.Remove(key);
        }
    }
    //3.2释放全部
    public void ClearAll()
    {
        //1 获得键的总数
        var keys = new List<string>(cache.Keys); 
        //2
        for (int i = 0; i < keys.Count; i++)
        {
            Clear(keys[i]);
        }
    }
    //4 回收对象：使用完对象返回池中【从画面中消失】
    //4.1即时回收对象
    public void CollectObject(GameObject go)
    {
        go.SetActive(false);
    }
    //4.2延时回收对象
    public void CollectObject(GameObject go,float delay)
    {
        StartCoroutine(DelayCollect(go, delay));
    }
    private IEnumerator DelayCollect(GameObject go, float delay)
    {
        yield return new WaitForSeconds(delay);
        CollectObject(go);    
    }
}

