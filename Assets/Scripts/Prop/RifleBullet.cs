using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 步枪子弹
/// </summary>
public class RifleBullet : Prop {

    public class RifleBullet01 : RifleBullet
    {
        private RifleBullet01()
        {
            propName = "第一型步枪子弹";
            propNumber = 0;
            propIntroduce = "这是第一型步枪子弹";
        }
        public static RifleBullet01 rifleBullet01 { get { return new RifleBullet01(); } }
        public override void Use()
        {
            
        }
    }

    public class RifleBullet02 : RifleBullet
    {
        private RifleBullet02()
        {
            propName = "第二型步枪子弹";
            propNumber = 0;
            propIntroduce = "这是第二型步枪子弹";
        }
        public static RifleBullet02 rifleBullet02 { get { return new RifleBullet02(); } }
        public override void Use()
        {

        }
    }

    public class RifleBullet03 : RifleBullet
    {
        private RifleBullet03()
        {
            propName = "第三型步枪子弹";
            propNumber = 0;
            propIntroduce = "这是第三型步枪子弹";
        }
        public static RifleBullet03 rifleBullet03 { get { return new RifleBullet03(); } }
        public override void Use()
        {

        }
    }
}
