using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GYFZ.Actor
{
    /// <summary>
    /// 角色动画系统
    /// </summary>
    public class ActorAnimation : MonoBehaviour
    {

        public string walk = "walk";
        public string run = "run";
        public string stand = "stand";
        public string back = "back";
        public string wave = "wave";
        public string DuiJiangJi = "DuiJiangJi";
        public string lay = "lay";
        public string Run_Hurt = "Run_Hurt";
        public string DownThenStandUp = "DownThenStandUp";
        public string DianHua = "DianHua";
        public string Down01 = "Down01";


        /// <summary>
        /// 动画组件
        /// </summary>
        private Animator anim;
        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
        }
        private string preAnimName = "stand";
        /// <summary>
        /// 播放动画=[开始播放，结束播放】
        /// </summary>
        public void PlayAnimation(string nowAnimName)
        {        
            anim.SetInteger(preAnimName, 1);
            anim.SetInteger(nowAnimName, 0);
            preAnimName = nowAnimName;
        }
    }
}
