using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GYFZ.Actor.Equipment
{
    public class EquipmentManager : MonoBehaviour
    {
        List<Equipment> equipmentList = new List<Equipment>();
        List<Equipment> currentEquipmentList = new List<Equipment>();
        public void Equipmenting(int eqID)//, bool on)
        {
            Equipment eq = ListHelper.Find(equipmentList, a => a.category == eqID);
            string ChildName = eq.name;
            if (eq._equipmentState == Equipment.EquipmentState.Unuseful)
            {
                currentEquipmentList.Add(eq);
            }
            else if (eq._equipmentState == Equipment.EquipmentState.Useful)
            {
                currentEquipmentList.Remove(eq);
            }
            RefreshModelEq(eq._equipmentState);
        }

        #region new equipmenting
        public void RefreshModelEq(Equipment.EquipmentState equipment)
        {
            //定body
            GameObject currentBody = this.gameObject;

            //同步当前护具表
            for (int i = 0; i < currentBody.transform.childCount; i++)
            {
                GameObject obj = currentBody.transform.GetChild(i).gameObject;

                //SingleBody的暂且进不来这里，防一下滤下名字
                if (obj.name != "Bip01" && obj.name != "pifu" && obj.name != "Plane_mark" && obj.name != "Canvas" && obj.name != "LightRing")
                {
                    //---------------------------------SupportTools.Highlight(obj, false);
                    if (equipment == Equipment.EquipmentState.Unuseful)
                    {
                        obj.SetActive(false);
                    }

                    for (int j = 0; j < currentEquipmentList.Count; j++)
                    {
                        if (obj.name == currentEquipmentList[j].name)
                        {
                            obj.SetActive(true);

                            if (wh && obj.name == lightName)//高亮一下
                            {
                                StopCoroutine(BlingObject(obj));
                                StartCoroutine(BlingObject(obj));
                            }
                        }

                        if (ListHelper.Find(currentEquipmentList, a => a.gearID == 200004 || a.gearID == 200005) != null)//背包 面具 坑 后来背包包含了面具
                        {
                            currentBody.transform.Find("MianJu").gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
        #endregion

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


        public virtual void SetEquipmentOn(bool wh)
        {
            isEquipped = wh;
        }

        public virtual void ConfirmEquipment()
        {
            isEquipped = true;

            //JudgeEquipment();

            DoMyJob();
        }
    }
}