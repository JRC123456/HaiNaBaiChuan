using System;
using System.Collections.Generic;

static public class ListHelper
{

    /// <summary>
    /// 1 返回最大对象
    /// </summary>
    /// <typeparam name="T">数据类型：如Student</typeparam>
    /// <typeparam name="TKey">数据类型的字段的类型：如int</typeparam>
    /// <param name="array">数据类型对象的数组</param>
    /// <param name="handler">选择委托对象</param>
    /// <returns>最大对象</returns>
    static public T Max<T, TKey>(List<T> array,
     SelectHandler<T, TKey> handler)
     where TKey : IComparable<TKey>
    {
        var max = array[0];
        for (int i = 1; i < array.Count; i++)
        {
            if (handler(max).CompareTo(handler(array[i])) < 0)
            {
                max = array[i];
            }
        }
        return max;
    }
    /// <summary>
    /// 2 返回最小对象
    /// </summary>
    /// <typeparam name="T">数据类型：如Student</typeparam>
    /// <typeparam name="TKey">数据类型的字段的类型：如int</typeparam>
    /// <param name="array">数据类型对象的数组</param>
    /// <param name="handler">选择委托对象</param>
    /// <returns>最大对象</returns>
    static public T Min<T, TKey>(List<T> array,
     SelectHandler<T, TKey> handler)
     where TKey : IComparable<TKey>
    {
        var min = array[0];
        for (int i = 1; i < array.Count; i++)
        {
            if (handler(min).CompareTo(handler(array[i])) > 0)
            {
                min = array[i];
            }
        }
        return min;
    }

    //冒泡
    //public static void OrderBy(int[] array)
    //{
    //    for (int i = 0; i < array.Length-1; i++)
    //    {
    //        for (int j =i+1; j < array.Length ; j++)
    //        {
    //            if (array[i].CompareTo(array[j]) > 0)
    //            {
    //                var temp = array[i];
    //                array[i] = array[j];
    //                array[j] = temp;
    //            }
    //        }
    //    }        
    //}
    /// <summary>
    ///3 升序排序
    /// </summary>
    /// <typeparam name="T">数据类型：如Student</typeparam>
    /// <typeparam name="TKey">数据类型的字段的类型：如int</typeparam>
    /// <param name="array">数据类型对象的数组</param>
    /// <param name="handler">选择委托对象</param>
    public static void OrderBy<T, TKey>(List<T> array,
        SelectHandler<T, TKey> handler)
        where TKey : IComparable<TKey>
    {
        for (int i = 0; i < array.Count - 1; i++)
        {
            for (int j = i + 1; j < array.Count; j++)
            {
                //var tkey1 = handler(array[i]);
                //var tkey2 = handler(array[j]);
                //var re = tkey1.CompareTo(tkey2);
                //if (array[i].CompareTo(array[j]) > 0)
                if (handler(array[i]).CompareTo(handler(array[j])) > 0)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
    /// <summary>
    /// 4 降序排序
    /// </summary>
    /// <typeparam name="T">数据类型：如Student</typeparam>
    /// <typeparam name="TKey">数据类型的字段的类型：如int</typeparam>
    /// <param name="array">数据类型对象的数组</param>
    /// <param name="handler">选择委托对象</param>
    public static void OrderByDescending<T, TKey>(List<T> array,
        SelectHandler<T, TKey> handler)
        where TKey : IComparable<TKey>
    {
        for (int i = 0; i < array.Count - 1; i++)
        {
            for (int j = i + 1; j < array.Count; j++)
            {
                //var tkey1 = handler(array[i]);
                //var tkey2 = handler(array[j]);
                //var re = tkey1.CompareTo(tkey2);
                //if (array[i].CompareTo(array[j]) > 0)
                if (handler(array[i]).CompareTo(handler(array[j])) < 0)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    /// <summary>
    /// 5 查找单个Find
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    public static T Find<T>(List<T> list, FindHandler<T> handler)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (handler(list[i]))
            {
                return list[i];
            }
        }
        return default(T);
    }

    /// <summary>
    /// 6 查找满足条件的所有的对象FindAll
    /// </summary>
    /// <typeparam name="T">数据类型：如Student</typeparam>
    /// <param name="array"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    public static T[] FindAllGetArray<T>(List<T> array, FindHandler<T> handler)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < array.Count; i++)
        {
            if (handler(array[i]))
            {
                list.Add(array[i]);
            }
        }
        return list.ToArray();
    }
    /// <summary>
    /// 找到满足条件所有对象，返回列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    public static List<T> FindAll<T>(List<T> array, FindHandler<T> handler)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < array.Count; i++)
        {
            if (handler(array[i]))
            {
                list.Add(array[i]);
            }
        }
        return list;
    }
    /// <summary>
    /// 选择Select【6】：
    /// 从对象集合中提取每个对象的某个属性的值做成一个新的数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <param name="array"></param>
    /// <param name="handler"></param>
    /// <returns></returns>
    public static TKey[] Select<T, TKey>(List<T> array,
        SelectHandler<T, TKey> handler)
    {
        TKey[] arrarNew = new TKey[array.Count];
        for (int i = 0; i < array.Count; i++)
        {
            arrarNew[i] = handler(array[i]);
        }
        return arrarNew;
    }
}

/// <summary>
/// 选择委托 代表 方法 ：TKey（T）
/// 从T类型对象中 选择TKey类型的字段，返回这个字段的值
/// </summary>
/// <typeparam name="T">数据类型：如Student</typeparam>
/// <typeparam name="TKey">数据类型的字段的类型：如int</typeparam>
/// <param name="t">数据类型的对象：如zsObj</param>
/// <returns>[zsObj.Age=]20  </returns>
public delegate TKey SelectHandler<T, TKey>(T t);//泛型委托

/// <summary>
/// 查找委托 代表 方法 ：bool（T）
/// 根据T的字段  构建条件表达式 zs id name age
///       zs.id>2&&zs.age>20
/// </summary>
/// <typeparam name="T">数据类型：如Student</typeparam>
/// <param name="t">数据类型的对象：如zsObj</param>
/// <returns>条件表达式结果：true，false</returns>
public delegate bool FindHandler<T>(T t);

