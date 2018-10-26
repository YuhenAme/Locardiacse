using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 步枪子弹
/// </summary>
public class RifleBullet : Prop {

    private void Awake()
    {
        this.propName = "步枪子弹";
        this.propNumber = 30;
    }
    /// <summary>
    /// 使用
    /// </summary>
    public override void Use()
    {
        
    }
}
