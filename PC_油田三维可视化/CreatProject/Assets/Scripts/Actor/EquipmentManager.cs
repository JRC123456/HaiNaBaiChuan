using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GYFZ.Actor.Equipment
{
    public class EquipmentManager : MonoBehaviour
    {
        List<Equipment> equipmentList = new List<Equipment>();//所属所有装备
        List<Equipment> currentEquipmentList = new List<Equipment>();//当前穿在身上的装备
        Dictionary<string, GameObject> dicEquipObj = new Dictionary<string, GameObject>();//装备物品字典

        public void Start()
        {
            InitEquipmentList();//初始化

        }

        /// <summary>
        /// 传递进来装备ID
        /// </summary>
        /// <param name="eqID"></param>
        public void Equipmenting(int eqID)//, bool on)
        {
            Equipment eq = ListHelper.Find(equipmentList, a => a.category == eqID);
            if (eq != null)
            {
                //如果装备是锁着的直接跳出
                if (eq._equipmentState == Equipment.EquipmentState.Lock) return;
                if (eq._equipmentState == Equipment.EquipmentState.Unuseful)
                {
                    currentEquipmentList.Add(eq);
                    eq._equipmentState = Equipment.EquipmentState.Useful;
                }
                else if (eq._equipmentState == Equipment.EquipmentState.Useful)
                {
                    currentEquipmentList.Remove(eq);
                    eq._equipmentState = Equipment.EquipmentState.Unuseful;
                }

                //刷新装备
                if (!dicEquipObj.ContainsKey(eq.name)) return;
                GameObject obj = dicEquipObj[eq.name];
                if (eq._equipmentState == Equipment.EquipmentState.Unuseful)
                    obj.SetActive(false);
                else
                {
                    obj.SetActive(true);
                    //物品出现要伴随高亮
                    StopCoroutine(BlingObject(obj));
                    StartCoroutine(BlingObject(obj));
                }
            }

        }

        /// <summary>
        /// 新上护具亮一下
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        IEnumerator BlingObject(GameObject o)
        {
            SupportTools.Highlight(o, true);
            yield return new WaitForSeconds(0.5f);
            SupportTools.Highlight(o, false);
        }

        /// <summary>
        /// 装备初始化
        /// </summary>
        void InitEquipmentList()
        {
            GameObject currentBody = this.gameObject;

            //先把物品字典 给存了
            for (int i = 0; i < currentBody.transform.childCount; i++)
            {
                GameObject obj = currentBody.transform.GetChild(i).gameObject;

                //SingleBody的暂且进不来这里，防一下滤下名字.防止别的
                if (obj.name != "Bip01" && obj.name != "pifu" && obj.name != "Plane_mark" && obj.name != "Canvas" && obj.name != "LightRing")
                {
                    dicEquipObj.Add(obj.name, obj);
                    //在吧装备信息列表初始化了
                    Equipment equipment01 = new Equipment
                    {
                        category = CreatEquipmentID(obj.name),
                        name = obj.name,
                        description = CreatEquipmentDescription(obj.name),
                        icon = CreatEquipmentIcon(obj.name),
                        owner = currentBody
                    };
                }
            }

        }


        int CreatEquipmentID(string equipmentName)
        {
            int currentID = 0;
            switch (equipmentName)
            {
                case "Box002":
                    currentID = 10001;
                    break;
                case "Sphere03":
                    currentID = 10002;
                    break;
                case "对象001":
                    currentID = 10003;
                    break;
                case "对象01":
                    currentID = 10004;
                    break;
                case "对象004":
                    currentID = 10005;
                    break;
                case "对象005":
                    currentID = 10006;
                    break;
                default:
                    Debug.LogError("装备ID初始化出错了，请及时排查！");
                    break;
            }
            return currentID;
        }

        string CreatEquipmentDescription(string equipmentName)
        {
            string currentDes = "";
            switch (equipmentName)
            {
                case "Box002":
                    currentDes = "";
                    break;
                case "Sphere03":
                    currentDes = "";
                    break;
                case "对象001":
                    currentDes = "";
                    break;
                case "对象01":
                    currentDes = "";
                    break;
                case "对象004":
                    currentDes = "";
                    break;
                case "对象005":
                    currentDes = "";
                    break;
                default:
                    Debug.LogError("装备介绍初始化出错了，请及时排查！");

                    break;
            }
            return currentDes;
        }

        Sprite CreatEquipmentIcon(string equipmentName)
        {
            string currentIconName = "";
            switch (equipmentName)
            {
                case "Box002":
                    currentIconName = "";
                    break;
                case "Sphere03":
                    currentIconName = "";
                    break;
                case "对象001":
                    currentIconName = "";
                    break;
                case "对象01":
                    currentIconName = "";
                    break;
                case "对象004":
                    currentIconName = "";
                    break;
                case "对象005":
                    currentIconName = "";
                    break;
                default:
                    Debug.LogError("装备Icon初始化出错了，请及时排查！");
                    break;
            }
            Sprite sprite = Resources.Load<Sprite>("Sprites/" + currentIconName);
            return sprite;
        }
    }
}