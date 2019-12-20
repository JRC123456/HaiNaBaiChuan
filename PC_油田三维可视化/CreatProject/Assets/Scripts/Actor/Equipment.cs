using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GYFZ.Actor.Equipment
{
   
    /// <summary>
    /// 装备
    /// </summary>
    public class Equipment
    {
        /// <summary>
        /// 种类
        /// </summary>
        public int category;
        /// <summary>
        /// 名称
        /// </summary>
        public string name;
        /// <summary>
        /// 描述
        /// </summary>
        public string description;
        /// <summary>
        /// 图片
        /// </summary>
        public Sprite icon;

        /// <summary>
        ///装备拥有者
        /// </summary>
        public GameObject owner;


        public enum EquipmentState
        {
            Lock,
            Useful,
            Unuseful
        }

        public EquipmentState  _equipmentState;
    }
}
