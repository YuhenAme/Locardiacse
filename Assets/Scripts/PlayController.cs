using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人物控制
/// </summary>
public class PlayController : MonoBehaviour {

    [SerializeField][Header("人物血量")]
    private float hp = 100;
    [SerializeField][Header("人物紧张值")][Range(0,100)]
    private float nervous = 0;
    [SerializeField][Header("当前持枪")]
    private GameSystem.Gun gun;

    public Prop[] currentBullets = new Prop[6];//当前弹夹
    private Prop currentBullet;//当前子弹
    private int bulletIndex = 0;//当前子弹索引

    int gunStateIndex = 0;

    private void Start()
    {
        gun = null;
    }
    //人物操作逻辑
    private void Update()
    {
        ChangeWeapon();
        ChangeBullets();
        Shoot();
    }


    //-------------------------------------------------------
    /// <summary>
    /// 移动
    /// </summary>
    private void Move()
    {

    }
    /// <summary>
    /// 蹲下
    /// </summary>
    private void Squat()
    {

    }
    /// <summary>
    /// 切换武器
    /// </summary>
    private void ChangeWeapon()
    {
        //切换逻辑
        if (Input.GetKeyDown(KeyCode.Q))
        {
            --gunStateIndex;
            if (gunStateIndex < 0) gunStateIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ++gunStateIndex;
            if (gunStateIndex > 2) gunStateIndex = 0;
        }
        //设置枪状态
        switch (gunStateIndex)
        {
            case 0:gun = null;Debug.Log("无枪械");break;
            case 1:gun = GameSystem.Pistol.pistol; Debug.Log(gun.GunState);break;
            case 2:gun = GameSystem.Rifle.rifle; Debug.Log(gun.GunState);break;
        }

    }
    /// <summary>
    /// 切换弹夹
    /// </summary>
    private void ChangeBullets()
    {
        if(gun == null)
        {
            Debug.Log("false");
            return;
        }
        else
        {
            if (gun.GunState == 1)
            {
                //当持枪为手枪时
                currentBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets01;//默认弹夹为01
                //按某个键切换弹夹
                //if (Input.GetKeyDown(KeyCode.I))
                //{
                //    currentBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets02;
                //}

            }
            if (gun.GunState == 2)
            {
                currentBullets = GameSystem.BulletSystem.Instance.setting.rifleBullets01;
            }
        }
    }
    /// <summary>
    /// 装弹
    /// </summary>
    private void Reload()
    {

    }
    /// <summary>
    /// 射击
    /// </summary>
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (bulletIndex > 5)
            {
                return;
            }
            else
            {
                currentBullet = GameSystem.BulletSystem.GetBullet(bulletIndex, currentBullets);
                //动态加载对应的子弹实例
                //背包系统对应子弹数量减少
                Debug.Log(currentBullet.propName);
                bulletIndex += 1;
            }
        }
        
    }
    /// <summary>
    /// 射击锁定
    /// </summary>
    private void LockEmeny()
    {

    }
    /// <summary>
    /// 搜索尸体
    /// </summary>
    private void SearchBody()
    {

    }
    /// <summary>
    /// 进门
    /// </summary>
    private void IntoDoor()
    {

    }
    /// <summary>
    /// 死亡判定
    /// </summary>
    /// <returns></returns>
    private bool IsAlive()
    {
        if (hp <= 0)
            return false;
        else
            return true;
    }
}
namespace GameSystem
{
    public class Gun
    {
        public int maxBulletNumber;//最大子弹数
        public int GunState;//当前枪的状态
        public int GunDamage;//子弹伤害
        public virtual void Init()
        {

        }
    }
    /// <summary>
    /// 手枪设置
    /// </summary>
    public class Pistol : Gun
    {
        public Pistol()
        {
            maxBulletNumber = 50;
            GunState = 1;
            GunDamage = 10;
        }

        public static Gun pistol { get { return new Pistol(); } }
    }
    /// <summary>
    /// 步枪设置
    /// </summary>
    public class Rifle : Gun
    {
        public Rifle()
        {
            maxBulletNumber = 30;
            GunState = 2;
            GunDamage = 30;
        }

        public static Gun rifle { get { return new Rifle(); } }
    }
}