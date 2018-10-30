using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameSystemInstance
{
    public class BattleSystemInstance : SystemInstance<BattleSystemInstance>
    {
        [Header("战斗系统")]
        public EmptyStruct 一一一一一一一一一一;
        [System.Serializable]
        public class Setting
        {
            //敌人的list
            public  List<GameObject> emenyList;
            //锁定的敌人
            public  GameObject lockedEmeny;
            
        }
        public Setting setting;
    }
}
namespace GameSystem
{
    public static class BattleSystem
    {
        //获取实例
        private static GameSystemInstance.BattleSystemInstance Instance { get { return GameSystemInstance.BattleSystemInstance.Instance; } }
        //加载设置
        private static GameSystemInstance.BattleSystemInstance.Setting Setting { get { return Instance.setting; } }

        private static int index = 0;
        private static int count;

        /// <summary>
        /// 返回emeny的list
        /// </summary>
        /// <returns></returns>
        public static List<GameObject> GetEmeny()
        {
            //敌人的list
            GameObject[] emenys = GameObject.FindGameObjectsWithTag("Emeny");
            foreach (GameObject emeny in emenys)
            {
                Vector2 emenyPos = Camera.main.WorldToViewportPoint(emeny.transform.position);
                if (emenyPos.x < 1 && emenyPos.x > 0 && emenyPos.y > 0 && emenyPos.y < 1)
                {
                    if (!Setting.emenyList.Contains(emeny))
                    {
                        Setting.emenyList.Add(emeny);
                    }
                }
                else
                {
                    if (Setting.emenyList.Contains(emeny))
                    {
                        Setting.emenyList.Remove(emeny);
                    }
                }
            }
            return Setting.emenyList;
           
        }
        /// <summary>
        /// 索敌
        /// </summary>
        /// <param name="emenys">emeny的list</param>
        /// <returns></returns>
        public static GameObject ChangeEmeny(List<GameObject> emenys)
        {
            count = emenys.Count;
            
            if (emenys == null)
                return null;
            if (Input.GetKeyDown(KeyCode.K))
            {
                index += 1;
                if (index >= count)
                {
                    index = 0;
                }
            }
            Setting.lockedEmeny = emenys[index];

            return Setting.lockedEmeny;
        }
        /// <summary>
        /// 阴影机制
        /// </summary>
        public static void Shadow()
        {
            Transform playerPos = GameObject.FindGameObjectWithTag("Player").transform;//得到主角的位置

        }
        

    }
}
