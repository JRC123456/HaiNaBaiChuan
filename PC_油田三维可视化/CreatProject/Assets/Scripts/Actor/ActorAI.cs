using UnityEngine;
using System.Collections;
namespace GYFZ.Actor
{
    /// <summary>
    /// 智能系统
    /// </summary>
    [RequireComponent(typeof(Motor), typeof(ActorAnimation))]
    public class ActorAI : MonoBehaviour
    {
        public ActorState state = ActorState.Idle;
        [HideInInspector]
        public Motor motor;
        private ActorAnimation anim;
        private void Start()
        {
            motor = GetComponent<Motor>();
            anim = GetComponent<ActorAnimation>();
        }

        public void Update()
        {
            switch (state)
            {
                case ActorState.Pathfinding:
                    DoPathfinding();
                    break;
                case ActorState.Phone:

                    DoingPhone();

                    break;
                case ActorState.UseTheTools:

                    break;
                case ActorState.ClothingEquipment:

                    break;
            }
        }

        //执行寻路
        private void DoPathfinding()
        {        
           
            if (motor.Pathfinding())
            {
                // 寻路完成
                state= ActorState.Idle;
                //动画切换成为站立动画
                anim.PlayAnimation(anim.stand);
            }
           
        }
        /// <summary>
        /// 打电话
        /// </summary>
        private void DoingPhone()
        {

        }


    }
}