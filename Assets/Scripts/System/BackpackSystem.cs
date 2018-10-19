using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystemInstance
{
    public class BackpackSystem : SystemInstance<BackpackSystem>
    {
        [Header("背包系统")]
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
    public class BackpackSystem
    {
        private GameSystemInstance.BackpackSystem Instance { get { return GameSystemInstance.BackpackSystem.Instance; } }
        private GameSystemInstance.BackpackSystem.Setting Setting { get { return Instance.setting; } }



    }
}