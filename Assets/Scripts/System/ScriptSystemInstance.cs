using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace GameSystemInstance
{
    public class ScriptSystemInstance : SystemInstance<ScriptSystemInstance>
    {
        [Header("剧本演出系统")]
        public EmptyStruct 一一一一一一一一一一;
        [System.Serializable]
        public class Setting
        {
            [Header("当前说话角色")]
            public string role;
            [Header("当前说话内容")]
            public string role_detail;
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

        //属性
        //存放对话的list
        private static List<string> dialogues_list;
        //当前对话的人物
        private static string role;
        //当前对话的内容
        private static string role_detail;
        //对话索引
        private static int dialogue_index = 0;
        //对话数量
        private static int dialogue_count = 0;

        //方法
        /// <summary>
        /// 获得当前对话
        /// </summary>
        private static void GetDialogue(int index)
        {
            //测试
            string[] role_detail_arry = dialogues_list[index].Split(',');
            role = role_detail_arry[0];
            role_detail = role_detail_arry[1];
            Setting.role = role;
            Setting.role_detail = role_detail;
        }
        /// <summary>
        /// 加载剧本
        /// </summary>
        /// <param name="name">剧本的名字</param>
        /// <param name="nodeName">当前剧本父节点名字</param>
        /// <returns></returns>
        private static List<string> GetScript(string name, string nodeName)
        {
            XmlDocument xmlDocument = new XmlDocument();//新建一个xml
            dialogues_list = new List<string>();

            string data = Resources.Load(name).ToString();//获取路径
            xmlDocument.LoadXml(data);//载入xml
            XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode(nodeName).ChildNodes;//获取指定父节点下的所有子节点
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                XmlElement xmlElement = (XmlElement)xmlNode;
                //加入list之中
                dialogues_list.Add(xmlElement.ChildNodes.Item(0).InnerText + "," + xmlElement.ChildNodes.Item(1).InnerText);
            }
            //获取对话的总数
            dialogue_count = dialogues_list.Count;

            return dialogues_list;
        }
        /// <summary>
        /// 移除列表中的元素
        /// </summary>
        /// <returns></returns>
        public static List<string> RemoveScript()
        {
            dialogues_list.Clear();
            Setting.role = null;
            Setting.role_detail = null;
            return dialogues_list;
        }


        /// <summary>
        /// 播放剧本
        /// </summary>
        /// <param name="name">剧本的名字</param>
        /// <param name="nodeName">当前剧本父节点名字</param>
        public static void PlayScript(string name,string nodeName)
        {
            //加载剧本
            GetScript(name, nodeName);
            //加载对话
            //GetDialogue(0);
            if (Input.GetMouseButtonDown(0))
            {
                if (dialogue_index < dialogue_count)
                    GetDialogue(dialogue_index);
                else
                    RemoveScript();//对话完毕
                dialogue_index++;
            }
        }
        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        public static string GetRole()
        {
            return Setting.role;
        }
        /// <summary>
        /// 获取对话
        /// </summary>
        /// <returns></returns>
        public static string GetRoleDetail()
        {
            return Setting.role_detail;
        }

    }
}
