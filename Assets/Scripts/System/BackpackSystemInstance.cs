using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

namespace GameSystemInstance
{
    public class BackpackSystemInstance : SystemInstance<BackpackSystemInstance>
    {
        [Header("背包系统")]
        public EmptyStruct 一一一一一一一一一一;
        [System.Serializable]
        public class Setting
        {
            [Header("默认存档")]
            public string defaultPath = @"d:/backpack.xml";
            [Header("存档1")]
            public string path1 = @"d:/backpack1.xml";
            [Header("存档2")]
            public string path2 = @"d:/backpack2.xml";
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
        //创建背包格子大小的临时背包
        public static Prop[] tempBackpack = new Prop[6];
        /// <summary>
        /// 初始化临时背包
        /// </summary>
        public static void InitTempBackpack()
        {
            tempBackpack[0] = PistolBullet.PistolBullet01.pistolBullet01;
            tempBackpack[1] = PistolBullet.PistolBullet02.pistolBullet02;
            tempBackpack[2] = PistolBullet.PistolBullet03.pistolBullet03;
            tempBackpack[3] = RifleBullet.RifleBullet01.rifleBullet01;
            tempBackpack[4] = RifleBullet.RifleBullet02.rifleBullet02;
            tempBackpack[5] = RifleBullet.RifleBullet03.rifleBullet03;
            
        }
        /// <summary>
        /// 加载临时背包
        /// </summary>
        public static void LoadTempBackpack()
        {
            backpack.Load(Setting.defaultPath);
            for (int i = 0; i < tempBackpack.Length; i++)
            {
                if(backpack.SelectSingleNode("//" + tempBackpack[i].propName) != null)
                {
                    string value;
                    value = backpack.SelectSingleNode("//" + tempBackpack[i].propName).ChildNodes[0].InnerText;
                    tempBackpack[i].propNumber = int.Parse(value);
                }
            }
        }
        /// <summary>
        /// 增加道具的数量
        /// </summary>
        /// <param name="name">道具名字</param>
        /// <param name="number">道具数量</param>
        public static void AddProp(string name,int number)
        {
            for (int i = 0; i < tempBackpack.Length; i++)
            {
                //Debug.Log(tempBackpack[5].propName);
                if(tempBackpack[i].propName == name)
                {
                    tempBackpack[i].propNumber += number;
                }
            }
        }
        /// <summary>
        ///移除道具的数量
        /// </summary>
        /// <param name="name">道具名字</param>
        /// <param name="number">道具数量</param>
        public static void RemoveProp(string name,int number)
        {
            for (int i = 0; i < tempBackpack.Length; i++)
            {
                if (tempBackpack[i].propName == name)
                {
                    tempBackpack[i].propNumber -= number;
                }
                if (tempBackpack[i].propNumber <= 0)
                    tempBackpack[i].propNumber = 0;
            }
        }
        /// <summary>
        /// 获得道具的数量
        /// </summary>
        /// <param name="name">道具名字</param>
        /// <returns></returns>
        public static int GetProp(string name)
        {
            for(int i = 0; i < tempBackpack.Length; i++)
            {
                if (tempBackpack[i].propName == name)
                    return tempBackpack[i].propNumber;
            }
            return 0;
        }
        /// <summary>
        /// 改变道具的数量
        /// </summary>
        /// <param name="name">道具名字</param>
        /// <param name="number">道具数量</param>
        public static void ChangeProp(string name,int number)
        {
            for (int i = 0; i < tempBackpack.Length; i++)
            {
                if (tempBackpack[i].propName == name)
                    tempBackpack[i].propNumber = number;
            }
        }
        /// <summary>
        /// 保存临时背包写入存档
        /// </summary>
        public static void SaveTempBackpack()
        {
            backpack.Load(Setting.defaultPath);
            for (int i = 0; i < tempBackpack.Length; i++)
            {
                if(backpack.SelectSingleNode("//" + tempBackpack[i].propName) != null)
                {

                    backpack.SelectSingleNode("//" + tempBackpack[i].propName).ChildNodes[0].InnerText = tempBackpack[i].propNumber.ToString();

                }
                
            }
            backpack.Save(Setting.defaultPath);
        }
        /// <summary>
        /// 创建背包xml
        /// </summary>
        /// <returns></returns>
        public static XmlDocument CreateBackpack()
        {
            string path = Setting.defaultPath;
            if (backpack == null)
            {
                //判断文件是否存在
                if (File.Exists(path))
                {
                    backpack = new XmlDocument();
                    backpack.Load(path);//存在则加载
                    return backpack;
                }
                else
                {
                    backpack = new XmlDocument();//不存在则创建
                    backpack.AppendChild(backpack.CreateXmlDeclaration("1.0", "gb2312", null));
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(Setting.defaultPath, null);
                    xmlTextWriter.Formatting = Formatting.Indented;

                    xmlTextWriter.WriteStartDocument();
                    xmlTextWriter.WriteStartElement("道具");//主节点
                                                          //子弹节点
                    xmlTextWriter.WriteStartElement("子弹数");
                    //手枪子弹数
                    xmlTextWriter.WriteStartElement("PistolBullet01");
                    xmlTextWriter.WriteStartElement("数量");
                    xmlTextWriter.WriteString("20");
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndElement();
                    //子弹数
                    xmlTextWriter.WriteStartElement("PistolBullet02");
                    xmlTextWriter.WriteStartElement("数量");
                    xmlTextWriter.WriteString("10");
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndElement();

                    xmlTextWriter.WriteStartElement("PistolBullet03");
                    xmlTextWriter.WriteStartElement("数量");
                    xmlTextWriter.WriteString("10");
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndElement();

                    xmlTextWriter.WriteStartElement("RiflelBullet01");
                    xmlTextWriter.WriteStartElement("数量");
                    xmlTextWriter.WriteString("0");
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndElement();

                    xmlTextWriter.WriteStartElement("RiflelBullet02");
                    xmlTextWriter.WriteStartElement("数量");
                    xmlTextWriter.WriteString("0");
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndElement();

                    xmlTextWriter.WriteStartElement("RiflelBullet03");
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
            }
            return backpack;
            
        }
        ///// <summary>
        ///// 得到对应道具的数量
        ///// </summary>
        ///// <returns></returns>
        //public static string GetProp(string nodeName)
        //{
        //    backpack.Load(Setting.defaultPath);
        //    if (backpack != null)
        //    {
        //        if(backpack.SelectSingleNode("//" + nodeName) != null)
        //        {
        //            string value;
        //            value = backpack.SelectSingleNode("//" + nodeName).ChildNodes[0].InnerText;
        //            return value;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
           
        //}
        ///// <summary>
        ///// 增加道具(向背包中加东西)
        ///// </summary>
        ///// <param name="nodeName"></param>
        //public static void AddProp(string nodeName,int number)
        //{
        //    backpack.Load(Setting.defaultPath);
        //    if(backpack != null)
        //    {
        //        if(backpack.SelectSingleNode("//" + nodeName) != null)
        //        {
        //            //节点存在时,道具数量增加
        //            string value;
        //            value = backpack.SelectSingleNode("//" + nodeName).ChildNodes[0].InnerText;
        //            value = ((int.Parse(value) + number).ToString());
        //            backpack.SelectSingleNode("//" + nodeName).ChildNodes[0].InnerText = value;
        //        }
        //        else
        //        {
        //            ////节点不存在时,创建道具节点
        //            //XmlNode root = backpack.SelectSingleNode("道具");
        //            //XmlElement thisNode = backpack.CreateElement(nodeName);//创建一个节点
        //            //XmlElement thisNumber = backpack.CreateElement("数量");
        //            //thisNumber.InnerText = number.ToString();
        //            //thisNode.AppendChild(thisNumber);
        //            return;
        //        }
        //    }
        //    backpack.Save(Setting.defaultPath);
        //}
        ///// <summary>
        ///// 移除道具(从背包中减少东西)
        ///// </summary>
        ///// <param name="nodeNome"></param>
        ///// <param name="number"></param>
        //public static void RemoveProp(string nodeName,int number)
        //{
        //    backpack.Load(Setting.defaultPath);
        //    string value;
        //    value = backpack.SelectSingleNode("//" + nodeName).ChildNodes[0].InnerText;
        //    if (int.Parse(value) > number)
        //        value = (int.Parse(value) - number).ToString();
        //    else
        //        value = "0";
        //    backpack.SelectSingleNode("//" + nodeName).ChildNodes[0].InnerText = value;
        //    backpack.Save(Setting.defaultPath);

        //}
        ///// <summary>
        ///// 改变道具的数量
        ///// </summary>
        ///// <param name="nodeName"></param>
        ///// <param name="number"></param>
        //public static void ChangeProp(string nodeName,int number)
        //{
        //    backpack.Load(Setting.defaultPath);
        //    backpack.SelectSingleNode("//" + nodeName).ChildNodes[0].InnerText = number.ToString();
        //    backpack.Save(Setting.defaultPath);
        //}

        /// <summary>
        /// 设置背包存档
        /// </summary>
        public static void SetBackpackPath()
        {
            //根据选择存档来设置背包路径
            //...
        }

        

    }
}