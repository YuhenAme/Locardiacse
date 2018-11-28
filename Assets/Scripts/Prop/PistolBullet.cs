using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 手枪子弹
/// </summary>
public class PistolBullet : Prop {
    /// <summary>
    /// 第一型手枪子弹
    /// </summary>
    public class PistolBullet01 : PistolBullet
    {
        private PistolBullet01()
        {
            propName = "PistolBullet01";
            propNumber = 10;
        }
        public static PistolBullet01 pistolBullet01 { get { return new PistolBullet01(); } }

        public override void Use()
        {
            
        }

    }

    public class PistolBullet02 : PistolBullet
    {
        private PistolBullet02()
        {
            propName = "PistolBullet02";
            propNumber = 10;
        }
        public static PistolBullet02 pistolBullet02 { get { return new PistolBullet02(); } }

        public override void Use()
        {

        }

    }

    public class PistolBullet03 : PistolBullet
    {
        private PistolBullet03()
        {
            propName = "PistolBullet03";
            propNumber = 10;
        }
        public static PistolBullet03 pistolBullet03 { get { return new PistolBullet03(); } }

        public override void Use()
        {

        }
    }



}

