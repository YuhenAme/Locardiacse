using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace GameSystemInstance
{
    public class EventSystemInstance : SystemInstance<EventSystemInstance>
    {
        [Header("事件系统")]
        public EmptyStruct 一一一一一一一一一一;
        [System.Serializable]
        public class Setting
        {

        }
        public Setting setting;

    }
}
namespace GameSystem
{
    public static class EventSystem
    {
        private static GameSystemInstance.EventSystemInstance Instance { get { return GameSystemInstance.EventSystemInstance.Instance; } }
        private static GameSystemInstance.EventSystemInstance.Setting Setting { get { return Instance.setting; } }

        //测试委托
        //可自定义委托类型
        private static event EventHandler EventHandlerControll;
        
        //委托测试
        private static void OpenEvent()
        {
            EventHandlerControll(Instance, null);
        }

        //注册事件
        private static void RegisterEvent(EventHandler e)
        {
            if (EventHandlerControll != null)
                EventHandlerControll += e;
            else
                EventHandlerControll = e;
        }
        //注销事件
        public static void CancelEvent()
        {
            //EventHandlerControll = null;
            while (EventHandlerControll != null)
            {
                EventHandlerControll -= EventHandlerControll;
            }
        }

        public static class FirstOpen
        {
            private static void Event1(object source, EventArgs e)
            {
                //GameObject gameObject = source as GameObject;
                Debug.Log("开门");
            }
            private static void Event2(object source, EventArgs e)
            {
                Debug.Log("开灯");
            }
            //第一次事件
            public static void FirstOpenEvent()
            {
                CancelEvent();
                RegisterEvent(Event1);
                RegisterEvent(Event2);
                OpenEvent();
            }
        }
    }
}
