using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //测试xml
        GameSystem.BackpackSystem.CreateBackpack();
        
    }
	
	// Update is called once per frame
	void Update () {

        //GameSystem.BattleSystem.GetEmeny();
        //GameSystem.ScriptSystem.PlayScript("dialogues", "dialogues");
        //Debug.Log(GameSystem.ScriptSystem.GetRole() + GameSystem.ScriptSystem.GetRoleDetail());

        //游戏流程控制系统调用事件,协程
        //GameSystem.EventSystem.FirstOpen.FirstOpenEvent();

        string s = GameSystem.BackpackSystem.GetProp("手枪子弹数量");
        Debug.Log(s);
        if (Input.GetMouseButtonDown(0))
        {
            GameSystem.BackpackSystem.AddProp("手枪子弹数量", 10);
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameSystem.BackpackSystem.RemoveProp("手枪子弹数量", 5);
        }
            

    }
}
