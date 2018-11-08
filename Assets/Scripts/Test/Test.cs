using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Test : MonoBehaviour {
    private PlayController player;
	// Use this for initialization
	void Start () {
        //测试xml
        GameSystem.BackpackSystem.CreateBackpack();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayController>();

    }
	
	// Update is called once per frame
	void Update () {
        //测试阴影------------------------------
        //GameSystem.BattleSystem.GetEmeny();
        //GameSystem.BattleSystem.Shadow();
        //测试剧本系统--------------------------
        //GameSystem.ScriptSystem.PlayScript("dialogues", "dialogues");
        //Debug.Log(GameSystem.ScriptSystem.GetRole() + GameSystem.ScriptSystem.GetRoleDetail());
        //--------------------------------------
        //游戏流程控制系统调用事件,协程---------
        //GameSystem.EventSystem.FirstOpen.FirstOpenEvent();
        //.-------------------------------------
        //测试背包加减道具----------------------
        //string s = GameSystem.BackpackSystem.GetProp("第一型手枪子弹");
        //Debug.Log(s);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    GameSystem.BackpackSystem.AddProp("第一型手枪子弹", 10);
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    GameSystem.BackpackSystem.RemoveProp("第一型手枪子弹", 5);
        //}
        //--------------------------------------  
        //测试子弹系统--------------------------
        //if (Input.GetMouseButtonDown(0))
        //{//设置子弹
        //    GameSystem.BulletSystem.SetBullet(0, PistolBullet.PistolBullet01.pistolBullet01, GameSystem.BulletSystem.Instance.setting.pistolBullets01);
        //    GameSystem.BulletSystem.SetBullet(1, PistolBullet.PistolBullet02.pistolBullet02, GameSystem.BulletSystem.Instance.setting.pistolBullets01);
        //    GameSystem.BulletSystem.SetBullet(2, PistolBullet.PistolBullet02.pistolBullet02, GameSystem.BulletSystem.Instance.setting.pistolBullets01);
        //    GameSystem.BulletSystem.SetBullet(3, PistolBullet.PistolBullet03.pistolBullet03, GameSystem.BulletSystem.Instance.setting.pistolBullets01);
        //    GameSystem.BulletSystem.SetBullet(4, PistolBullet.PistolBullet01.pistolBullet01, GameSystem.BulletSystem.Instance.setting.pistolBullets01);
        //    GameSystem.BulletSystem.SetBullet(5, PistolBullet.PistolBullet02.pistolBullet02, GameSystem.BulletSystem.Instance.setting.pistolBullets01);
        //    //if (player.currentBullets != null)
        //    //{
        //    //    for (int i = 0; i <= 5; i++)
        //    //    {
        //    //        Debug.Log(GameSystem.BulletSystem.GetBullet(i, player.currentBullets).propName);
        //    //    }
        //    //}
        //}





    }
}
