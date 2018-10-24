using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具类
/// </summary>
public class Prop : MonoBehaviour {

    public enum PropEnum { PistolBullet, RifleBullet,Other}
    public PropEnum propEnum;
    //道具名字
    public string propName;
    //道具数量
    public int propNumber;
    //道具使用效果
    public virtual void Use()
    {

    }
    private void Awake()
    {
        switch (propEnum)
        {
            case PropEnum.PistolBullet: propName = "手枪子弹数量";break;
            case PropEnum.RifleBullet:  propName = "步枪子弹数量";break;
            case PropEnum.Other:        propName = "其他道具";break;

        }
    }
}
