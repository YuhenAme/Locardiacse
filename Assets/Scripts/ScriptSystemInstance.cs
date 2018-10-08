using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    public class ScriptSystemInstance : SystemInstance<ScriptSystemInstance>
    {
        [Header("剧本演出系统")]
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
    public static class ScriptSystem
    {
        //获取实例
        private static GameSystemInstance.ScriptSystemInstance Instance { get { return GameSystemInstance.ScriptSystemInstance.Instance; } }
        //获取设置
        private static GameSystemInstance.ScriptSystemInstance.Setting Setting { get { return Instance.setting; } }





    }
}
