using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
/// <summary>
/// 剧本演出系统,基类
/// </summary>
public class ScriptSystem : MonoBehaviour {

    //存放对话的list
    protected List<string> dialogues_list;
    //当前对话的人物
    protected string role;
    //当前对话的内容
    protected string role_detail;
    //对话索引
    protected int dialogue_index = 0;
    //对话数量
    protected int dialogue_count = 0;


    /// <summary>
    /// 播放剧本的方法
    /// </summary>
    public virtual void PlayScript()
    {

    }

   /// <summary>
   /// 载入对应的剧本
   /// </summary>
   /// <param name="name">剧本的名字</param>
   /// <param name="nodeName">剧本父节点名字</param>
   /// <returns></returns>
    public List<string> GetScript(string name,string nodeName)
    {
        XmlDocument xmlDocument = new XmlDocument();//新建一个xml
        dialogues_list = new List<string>();

        string data = Resources.Load(name).ToString();//获取路径
        xmlDocument.Load(data);//载入xml
        XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode(nodeName).ChildNodes;//获取指定父节点下的所有子节点
        foreach(XmlNode xmlNode in xmlNodeList)
        {
            XmlElement xmlElement = (XmlElement)xmlNode;
            //加入list之中
            dialogues_list.Add(xmlElement.ChildNodes.Item(0).InnerText + "," + xmlElement.ChildNodes.Item(1).InnerText);
        }
        //获取对话的总数
        dialogue_count = dialogues_list.Count;

        return dialogues_list;
    }
}
