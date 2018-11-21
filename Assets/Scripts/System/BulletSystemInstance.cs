using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameSystemInstance
{
    public class BulletSystemInstance : SystemInstance<BulletSystemInstance>
    {
        [Header("子弹系统")]
        public EmptyStruct 一一一一一一一一一一;

        [System.Serializable]
        public class Setting
        {
            //手枪弹夹1
            public Prop[] pistolBullets01 = new PistolBullet[6];
            //手枪弹夹2
            public Prop[] pistolBullets02 = new PistolBullet[6];
            //手枪弹夹3
            public Prop[] pistolBullets03 = new PistolBullet[6];
            //步枪弹夹1
            public Prop[] rifleBullets01 = new RifleBullet[6];
            //步枪弹夹2
            public Prop[] rifleBullets02 = new RifleBullet[6];
            //步枪弹夹3
            public Prop[] rifleBullets03 = new RifleBullet[6];

        }
        public Setting setting;
    }
}
namespace GameSystem
{
    public static class BulletSystem
    {
        public static GameSystemInstance.BulletSystemInstance Instance { get { return GameSystemInstance.BulletSystemInstance.Instance; } }
        private static GameSystemInstance.BulletSystemInstance.Setting Setting { get { return Instance.setting; } }
    
       /// <summary>
       /// 设置子弹
       /// </summary>
       /// <param name="index">子弹索引</param>
       /// <param name="bullet">子弹</param>
       /// <param name="pistolBullets">弹夹</param>
        public static void SetBullet(int index,Prop bullet,Prop[] bullets)
        {
            bullets[index] = bullet;
        }
        /// <summary>
        /// 得到子弹
        /// </summary>
        /// <param name="index">子弹索引</param>
        /// <param name="bullets">弹夹</param>
        public static Prop GetBullet(int index,Prop[] bullets)
        {
            return (bullets[index]);
        }
        /// <summary>
        /// 复制弹夹
        /// </summary>
        /// <param name="p1">被复制的弹夹</param>
        /// <param name="p2">复制的弹夹</param>
        public static void CopyBullets(Prop[] p1,Prop[] p2)
        {
            p2 = p1;
        }
        /// <summary>
        /// 删除弹夹配置
        /// </summary>
        /// <param name="p"></param>
        public static void DeleteBullets(Prop[] p)
        {
            p = null;
        }
        /// <summary>
        /// 与背包系统交互,根据弹夹减少子弹数量
        /// </summary>
        public static void ChangeBulletsNumber(Prop[] p)
        {
            if (p != null)
            {
                for (int i = 0; i < 6; i++)
                {
                    GameSystem.BackpackSystem.RemoveProp(p[i].propName, 1);
                }

            }
            else
            {
                return;
            }
            
        }
    }
}