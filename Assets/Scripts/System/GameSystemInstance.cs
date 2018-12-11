using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    [RequireComponent(typeof(BulletSystemInstance))]
    [RequireComponent(typeof(BackpackSystemInstance))]
    [RequireComponent(typeof(AudioSystemInstance))]
    [RequireComponent(typeof(BattleSystemInstance))]
    [RequireComponent(typeof(ScriptSystemInstance))]
    [RequireComponent(typeof(EventSystemInstance))]
    public class GameSystemInstance : MonoBehaviour
    {
        private PlayController player;
        public static bool isRemind = true;
        void Start()
        {
            //测试xml
            GameSystem.BackpackSystem.CreateBackpack();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayController>();
            GameSystem.BackpackSystem.InitTempBackpack();
            GameSystem.BackpackSystem.LoadTempBackpack();
            //教程提示用图来表示吧

        }
        //写流程控制-------------
        private void Update()
        {
            
            
        }



    }
    /// <summary>
    /// 子系统的父类
    /// </summary>
    /// <typeparam name="systemClass"></typeparam>
    public class SystemInstance<systemClass> : MonoBehaviour
    {
        private static systemClass instance;
        public static systemClass Instance
        {
            get
            {
                if (instance == null) instance = GameObject.Find("GameSystem").GetComponent<systemClass>();
                return instance;
            }
        }
    }
    [System.Serializable]
    public struct EmptyStruct { }
}

