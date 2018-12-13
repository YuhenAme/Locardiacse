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
            [Header("敌人列表")]
            public  List<GameObject> emenyList;
            [Header("锁定的敌人")]
            public  GameObject lockedEmeny;
            [Header("光列表")]
            public List<GameObject> lightList;
            [Header("阴影放大系数")][Range(1.0f,2.0f)]
            public float shadowCoefficient = 1;
            [Header("射击口位置")]
            public Transform firePosition;
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

        //private static List<GameObject> lights; 
        private static int index = 0;
        private static int count;
        private static GameObject player = GameObject.FindGameObjectWithTag("Player");
        public static GameObject bulletInstances = GameObject.Find("bulletInstances");
        
        /// <summary>
        /// 返回emeny的list
        /// </summary>
        /// <returns></returns>
        public static List<GameObject> GetEmeny()
        {
            Setting.emenyList = GetObjects(Setting.emenyList, "Emeny");
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
            GetLights();
            GameObject shadow = GameObject.FindGameObjectWithTag("ShadowController").transform.GetChild(0).gameObject;//阴影
            Transform playerPos = GameObject.FindGameObjectWithTag("Player").transform;//得到主角的位置
            //玩家的高度
            float playerHeight = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().bounds.size.y;
            Vector3 playerHeightPoint = new Vector3(playerPos.position.x, (playerPos.position.y + playerHeight / 2), 0);
            float defaultShadowSize = shadow.GetComponent<BoxCollider2D>().bounds.size.x;//默认阴影的长度
            //对每个处于屏幕内的光照
            foreach (GameObject light in Setting.lightList)
            {
                float lightRightPos = light.GetComponent<MyLight>().rightDis;
                float lightLeftPos = light.GetComponent<MyLight>().leftDis;
                float scaleX2;
                //当主角进入光照范围内开始产生阴影
                //计算出相切时的位置
                Vector3 LightLine = light.transform.position - (new Vector3(light.transform.position.x - lightLeftPos, 0, 0));
                float shadowSizeMax = (playerHeight * Mathf.Abs(LightLine.x)) / LightLine.y;
                if (playerPos.position.x>(light.transform.position.x-lightLeftPos) && playerPos.position.x < light.transform.position.x)
                {
                    //出现阴影
                    shadow.SetActive(true);
                    float shadowSize;
                   
                    //左半部分
                    if (playerPos.position.x<(light.transform.position.x - lightLeftPos + shadowSizeMax))
                    {
                        shadowSize = playerPos.position.x - (light.transform.position.x - lightLeftPos);
                        scaleX2 = (shadowSize * shadow.transform.localScale.x) / defaultShadowSize;
                    }
                    else
                    {
                        //随人物位置变化的射线，实时;
                        Vector3 LightLineChange = light.transform.position - playerHeightPoint;
                        shadowSize = (playerHeight * Mathf.Abs(LightLineChange.x)) / LightLineChange.y + 0.3f;
                        scaleX2 = (shadowSize * shadow.transform.localScale.x) / defaultShadowSize;
                    }
                    if (scaleX2 <= 0.5f)
                        scaleX2 = 0.5f;
                    shadow.transform.localScale = new Vector3(scaleX2*Setting.shadowCoefficient, 1, 1);
                    //计算阴影的相对位置!!!!!
                    shadow.transform.localPosition = new Vector3(-(0.1f+(shadowSize / 2)), shadow.transform.localPosition.y, 0);

                }
                else if(playerPos.position.x>light.transform.position.x && playerPos.position.x< light.transform.position.x + lightRightPos)
                {
                    //出现阴影
                    shadow.SetActive(true);
                    float shadowSize;
                    //随人物位置变化的射线，实时;
                    Vector3 LightLineChange = light.transform.position - playerHeightPoint;
                    //右半部分
                    if (playerPos.position.x > (light.transform.position.x + lightRightPos - shadowSizeMax))
                    {
                        shadowSize = (light.transform.position.x + lightRightPos) - playerPos.position.x;
                        scaleX2 = (shadowSize * shadow.transform.localScale.x) / defaultShadowSize;
                    }
                    else
                    {
                        shadowSize = (playerHeight * Mathf.Abs(LightLineChange.x)) / LightLineChange.y + 0.3f;
                        scaleX2 = (shadowSize * shadow.transform.localScale.x) / defaultShadowSize;
                    }
                    if (scaleX2 <= 0.5f)
                        scaleX2 = 0.5f;
                    shadow.transform.localScale = new Vector3(scaleX2 * Setting.shadowCoefficient, 1, 1);
                    //计算阴影的相对位置!!!!!
                    shadow.transform.localPosition = new Vector3(-0.1f+(shadowSize / 2), shadow.transform.localPosition.y, 0);

                }
                else
                {
                    //阴影消失
                    shadow.SetActive(false);
                }

            }


        }
       /// <summary>
       /// 对象池实例化子弹
       /// </summary>
       /// <param name="tag">子弹的标签</param>
        public static void InstanceBullet(string tag)
        {
            //对象池中子弹总数量
            int number = bulletInstances.transform.childCount;
            GameObject clone;
            if (number > 0)
            {
                for (int i =number-1; i >=0; i--)
                {
                    if (bulletInstances.transform.GetChild(i).tag == tag)
                    {
                        //若查询到则直接将子弹设置为可见
                        clone = bulletInstances.transform.GetChild(i).gameObject;
                        clone.SetActive(true);
                        clone.transform.parent = null;//脱离父物体
                        clone.transform.position = Setting.firePosition.position;//设置位置
                        clone.GetComponent<BulletInstance>().moveDir = new Vector3(player.transform.localScale.x, 0, 0);
                        clone.transform.localScale = new Vector3(player.transform.localScale.x * clone.transform.localScale.x, clone.transform.localScale.y, 0);
                        return;
                    }
                }
                //若没有查询到则实例化子弹
                clone = Resources.Load<GameObject>(tag);
                clone.GetComponent<BulletInstance>().moveDir = new Vector3(player.transform.localScale.x, 0, 0);
                GameObject clonePrefab = GameObject.Instantiate(clone, Setting.firePosition.position, Setting.firePosition.rotation);
                clonePrefab.transform.localScale = new Vector3(-player.transform.localScale.x * clonePrefab.transform.localScale.x, clonePrefab.transform.localScale.y, 0);
                clone.tag = tag;
            }
            else
            {
                //若没有查询到则实例化子弹
                clone = Resources.Load<GameObject>(tag);
                clone.GetComponent<BulletInstance>().moveDir = new Vector3(player.transform.localScale.x, 0, 0);
                //clone.transform.localScale = new Vector3(player.transform.localScale.x * clone.transform.localScale.x, clone.transform.localScale.y, 0);
                GameObject clonePrefab= GameObject.Instantiate(clone, Setting.firePosition.position,Setting.firePosition.rotation);
                clonePrefab.transform.localScale = new Vector3(-player.transform.localScale.x * clonePrefab.transform.localScale.x, clonePrefab.transform.localScale.y, 0);
                clone.tag = tag;
                
            }
           

        }

        /// <summary>
        /// 获取处于屏幕范围内的光照
        /// </summary>
        /// <returns></returns>
        private static List<GameObject> GetLights()
        {
            Setting.lightList = GetObjects(Setting.lightList, "Light");
            return Setting.lightList;
        }


        /// <summary>
        /// 获取屏幕内物体的方法
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        private static List<GameObject> GetObjects(List<GameObject> objects,string tag)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach(GameObject go in gameObjects)
            {
                Vector2 goPos = Camera.main.WorldToViewportPoint(go.transform.position);
                if(goPos.x<1 && goPos.x>0 && goPos.y<1 && goPos.y > 0)
                {
                    if (!objects.Contains(go))
                    {
                        objects.Add(go);
                    }
                }
                else
                {
                    if (objects.Contains(go))
                    {
                        objects.Remove(go);
                    }
                }
            }
            return objects;
        }


    }
}
