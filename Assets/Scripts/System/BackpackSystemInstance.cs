using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

namespace GameSystemInstance
{
    public class BackpackSystemInstance : SystemInstance<BackpackSystemInstance>
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
    public static class BackpackSystem
    {
        private static GameSystemInstance.BackpackSystemInstance Instance { get { return GameSystemInstance.BackpackSystemInstance.Instance; } }
        private static GameSystemInstance.BackpackSystemInstance.Setting Setting { get { return Instance.setting; } }
        private static XmlDocument backpack;


        /// <summary>
        /// 创建背包xml
        /// </summary>
        /// <returns></returns>
        public static XmlDocument CreateBackpack()
        {
            if (backpack == null)
            {
                backpack = new XmlDocument();
                backpack.AppendChild(backpack.CreateXmlDeclaration("1.0", "gb2312", null));
            }
            XmlTextWriter xmlTextWriter = new XmlTextWriter(@"d:/backpack.xml", null);
            xmlTextWriter.Formatting = Formatting.Indented;

            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("道具");//主节点
            //子弹节点
            xmlTextWriter.WriteStartElement("子弹数");
            //手枪子弹数
            xmlTextWriter.WriteStartElement("手枪子弹数量");
            xmlTextWriter.WriteStartElement("数量");
            xmlTextWriter.WriteString("0");
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndElement();
            //步枪子弹数
            xmlTextWriter.WriteStartElement("步枪子弹数量");
            xmlTextWriter.WriteStartElement("数量");
            xmlTextWriter.WriteString("0");
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndElement();
            //子弹节点结束
            xmlTextWriter.WriteEndElement();
            //其他道具节点
            xmlTextWriter.WriteStartElement("其他道具");
            xmlTextWriter.WriteStartElement("数量");
            xmlTextWriter.WriteString("0");
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement();//主节点结束
      
            xmlTextWriter.Close();


            return backpack;
        }
        /// <summary>
        /// 得到对应道具的数量
        /// </summary>
        /// <returns></returns>
        public static string GetProp(string nodeName)
        {
            backpack.Load(@"d:/backpack.xml");
            if (backpack != null)
            {
                Debug.Log(backpack.SelectSingleNode("//步枪子弹数量").ToString());
                string value;
                //value = backpack.GetElementsByTagName(nodeName)[0].Value;
                value = backpack.SelectSingleNode("//"+nodeName).Value;
                //Debug.Log(value);
                return value;
            }
            else
            {
                return null;
            }
           
        }

    }
}