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

    int gunStateIndex = 0;

    private void Start()
    {
        gun = null;
    }
    //人物操作逻辑
    private void Update()
    {
        ChangeWeapon();
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
            case 1:gun = GameSystem.Pistol.pistol;gun.Init(); Debug.Log(gun.GunState);break;
            case 2:gun = GameSystem.Rifle.rifle;gun.Init(); Debug.Log(gun.GunState);break;
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

    }
    /// <summary>
    /// 射击锁定
    /// </summary>
    private void LockEmeny()
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
        public override void Init()
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
        public override void Init()
        {
            maxBulletNumber = 30;
            GunState = 2;
            GunDamage = 30;
        }

        public static Gun rifle { get { return new Rifle(); } }
    }
}