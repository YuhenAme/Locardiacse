using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具类
/// </summary>
public class Prop : MonoBehaviour {

    //道具名字
    [Header("道具名字")]
    public string propName;
    //道具数量
    [Header("道具数量")]
    public int propNumber;
    //道具使用效果
    public virtual void Use()
    {

    }
    
}
