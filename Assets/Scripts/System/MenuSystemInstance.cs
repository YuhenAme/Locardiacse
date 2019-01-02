using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystemInstance
{
    public class MenuSystemInstance : SystemInstance<MenuSystemInstance>
    {
        [Header("UI事件系统")]
        public EmptyStruct 一一一一一一一一一一;
        [System.Serializable]
        public class Setting
        {
            //主UI
            public Transform NormalUI;
            
            public Transform KeepAboveUI;

            public  Dictionary<UIType, BaseUI> NormalUIDic = new Dictionary<UIType, BaseUI>();
            public  BaseUI CurrentUI;

        }
        public Setting setting;
        

        private void Start()
        {
            
            
        }


        
        //--------------------------------------------

        //背包系统UI----------------------------------
        //呼出背包UI界面
        //public void OnBackpackButtonDown()
        //{
        //    backpackUI.SetActive(true);
        //    //加载背包内的数据，显示到UI
        //    int i = 0;int j = 1;
        //    while (i < GameSystem.BackpackSystem.tempBackpack.Length)
        //    {
        //        if(GameSystem.BackpackSystem.tempBackpack[i].propNumber != 0)
        //        {
        //            //如果当前格子下没有子物体
        //            if(backpackUI.transform.GetChild(j).childCount == 0)
        //            {
        //                GameObject thePicture = Resources.Load<GameObject>(GameSystem.BackpackSystem.tempBackpack[i].propName + "Picture");
        //                GameObject picture = Instantiate(thePicture);
        //                picture.transform.SetParent(backpackUI.transform.GetChild(j));
        //                picture.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        //                //当前的格子赋值
        //                backpackGrads[j - 1] = GameSystem.BackpackSystem.tempBackpack[i];
        //            }
        //            else
        //            {
        //                //先判断该物体是否存在，如果存在则跳过，如果不存在则找到一个空的格子，生成
        //                if (GameObject.Find(GameSystem.BackpackSystem.tempBackpack[i].propName+"Picture(Clone)") == null)
        //                {
        //                    //找到为空的格子
        //                    //边界为格子的数量
        //                    while (j < 25)
        //                    {
        //                        if (backpackUI.transform.GetChild(j).childCount == 0)
        //                            break;
        //                        else
        //                            j++;
        //                    }
        //                    GameObject thePicture = Resources.Load<GameObject>(GameSystem.BackpackSystem.tempBackpack[i].propName + "Picture");
        //                    GameObject picture = Instantiate(thePicture);
        //                    picture.transform.SetParent(backpackUI.transform.GetChild(j));
        //                    picture.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        //                    //当前的格子赋值
        //                    backpackGrads[j - 1] = GameSystem.BackpackSystem.tempBackpack[i];
        //                }
                        
        //            }
        //            i = i + 1;
        //            j = j + 1;
        //        }
        //        else
        //        {
        //            if(GameObject.Find(GameSystem.BackpackSystem.tempBackpack[i].propName) != null)
        //            {
        //                GameObject destroy = GameObject.Find(GameSystem.BackpackSystem.tempBackpack[i].propName);
        //                //获取该物体的父物体
        //                GameObject destroyParent = destroy.transform.parent.gameObject;
        //                backpackGrads[int.Parse(destroyParent.name) - 1] = null;
        //                Destroy(destroy);
        //            }
        //            i++;
        //        }

        //    }

        //}
        //public void ExitBackpackButton()
        //{
        //    backpackUI.SetActive(false);
        //}
        //public void SelectProp()
        //{
        //    GameObject propName = backpackUI.transform.GetChild(26).gameObject;
        //    GameObject propNumber = backpackUI.transform.GetChild(27).gameObject;
        //    GameObject propIntroduce = backpackUI.transform.GetChild(28).gameObject;
        //    var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        //    if(backpackGrads[int.Parse(button.name)-1] != null)
        //    {
        //        propName.GetComponent<Text>().text ="道具名字: " + backpackGrads[int.Parse(button.name) - 1].propName;
        //        propNumber.GetComponent<Text>().text = "道具数量: " + backpackGrads[int.Parse(button.name) - 1].propNumber;
        //        propIntroduce.GetComponent<Text>().text ="道具介绍: " + backpackGrads[int.Parse(button.name) - 1].propIntroduce;
        //    }
        //    else
        //    {
        //        propName.GetComponent<Text>().text = "道具名字: " + "无";
        //        propNumber.GetComponent<Text>().text = "道具数量: " + "无";
        //        propIntroduce.GetComponent<Text>().text = "道具介绍: " + "无";
        //    }
        //}
        //--------------------------------------------

        
      
    }
}
namespace GameSystem
{
    public static class MenuSystem
    {
        private static GameSystemInstance.MenuSystemInstance Instance { get { return GameSystemInstance.MenuSystemInstance.Instance; } }
        private static GameSystemInstance.MenuSystemInstance.Setting Setting { get { return Instance.setting; } }

       

        public static void OpenNormalUI(UIType uiType)
        {
            if(Setting.CurrentUI != null)
            {
                Setting.CurrentUI.CloseUI();
            }
            if (Setting.NormalUIDic.ContainsKey(uiType))
            {
                Setting.CurrentUI = Setting.NormalUIDic[uiType];
            }
            else
            {
                //Debug.Log(UIPath[uiType]);
                BaseUI theUI = GameObject.Instantiate(Resources.Load<BaseUI>(UIPath[uiType])) as BaseUI;
                AddChild(theUI.transform, Setting.NormalUI);
                Setting.NormalUIDic.Add(uiType, theUI);
                Setting.CurrentUI = theUI;
            }
            Setting.CurrentUI.OpenUI();
        }


        /// <summary>
        /// UI预制体的存放路径
        /// </summary>
        private static Dictionary<UIType, string> UIPath = new Dictionary<UIType, string>
        {
            {UIType.BulletUI,"UIPrefabs/BulletUI"},{UIType.BackpackUI,"UIPrefabs/BackpackUI"},
        };
        /// <summary>
        /// 添加子物体
        /// </summary>
        /// <param name="child">子物体</param>
        /// <param name="parent">父物体</param>
        private static void AddChild(Transform child, Transform parent)
        {
            child.SetParent(parent.transform);
            child.localPosition = Vector3.zero;
            child.localScale = Vector3.one;
            child.localEulerAngles = Vector3.zero;
        }
        /// <summary>
        /// 按名字获取子物体
        /// </summary>
        /// <param name="parent">父物体</param>
        /// <param name="childName">子物体的名字</param>
        /// <returns></returns>
        public static GameObject FindChildByName(GameObject parent, string childName)
        {
            if (parent.name == childName)
                return parent;
            if (parent.transform.childCount < 1)
                return null;
            GameObject obj = null;
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                //递归
                GameObject go = parent.transform.GetChild(i).gameObject;
                obj = FindChildByName(go, childName);
                if (obj != null)
                {
                    break;
                }
            }
            return obj;
        }
    }
}
