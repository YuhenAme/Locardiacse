using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人物控制
/// </summary>
public class PlayController : MonoBehaviour {

    [Header("血量")]
    public float hp = 100;
    [Header("紧张值")][Range(0,100)]
    public float nervous = 0;
    [Header("当前持枪")]
    public GameSystem.Gun gun;
    [SerializeField][Header("移动速度")][Range(0.1f,10)]
    private float moveSpeed = 7;

    public GameObject lockedEmeny;
    public Prop[] currentBullets = new Prop[6];//当前弹夹
    public Prop currentBullet;//当前子弹
    public int bulletIndex = 0;//当前子弹索引
    private Animator animator;

    static string animationName;//动画名字
    static string animationState;//动画状态转换值
    int gunStateIndex = 0;
    GameObject controller;

    private void Start()
    {
        
        gun = null;
        animator = GetComponent<Animator>();
        controller = GameObject.FindGameObjectWithTag("ShadowController");
    }
    //人物操作逻辑
    private void Update()
    {

        Move();
        ChangeWeapon();
        ChangeBullets();
        Shoot();
        LockEmeny();
        Reload(currentBullets);
        PlayAnimationOver(animator, animationState, animationName);

        //Debug.Log(lockedEmeny);
    }


    //-------------------------------------------------------
    /// <summary>
    /// 移动
    /// </summary>
    private void Move()
    {
        controller.transform.position = new Vector3(transform.position.x, controller.transform.position.y, controller.transform.position.z);

        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, 0, 0)*Time.deltaTime*moveSpeed;
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isMove", true);
            Vector3 scale = transform.localScale;
            if (scale.x > 0)
            {
                if (Input.GetKey(KeyCode.A))
                    scale.x *= -1;
                else
                    return;
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                    scale.x *= -1;
                else
                    return;
            }
            transform.localScale = scale;
            
        }
        else
        {
            animator.SetBool("isMove", false);
        }
       
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
            case 0:gun = null;break;//Debug.Log("无枪械");break;
            case 1:gun = GameSystem.Pistol.pistol; Debug.Log("当前为手枪");break;
            case 2:gun = GameSystem.Rifle.rifle; Debug.Log("当前为步枪");break;
        }

    }
    /// <summary>
    /// 切换弹夹
    /// </summary>
    private void ChangeBullets()
    {
        if(gun == null)
        {
            //Debug.Log("false");
            return;
        }
        else
        {
            if (gun.GunState == 1)
            {
                if (currentBullets != null)
                {
                    Debug.Log(currentBullets.ToString());
                }
                //当持枪为手枪时
                //currentBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets01;//默认弹夹为01
                //按某个键切换弹夹，1为弹夹1，2为弹夹2，3为弹夹3
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("更换为1号弹夹");
                    bulletIndex = 0;
                    currentBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets01;
                    //对应背包交互
                    //减少对应的子弹数量,子弹数量立即从背包中减少，而不是通过射出子弹而减少数量s
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Debug.Log("更换为2号弹夹");
                    bulletIndex = 0;
                    currentBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets02;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Debug.Log("更换为3号弹夹");
                    bulletIndex = 0;
                    currentBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets03;
                }
            }
            if (gun.GunState == 2)
            {
                //currentBullets = GameSystem.BulletSystem.Instance.setting.rifleBullets01;
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("更换为1号弹夹");
                    bulletIndex = 0;
                    currentBullets = GameSystem.BulletSystem.Instance.setting.rifleBullets01;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Debug.Log("更换为2号弹夹");
                    bulletIndex = 0;
                    currentBullets = GameSystem.BulletSystem.Instance.setting.rifleBullets02;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Debug.Log("更换为3号弹夹");
                    bulletIndex = 0;
                    currentBullets = GameSystem.BulletSystem.Instance.setting.rifleBullets03;
                }
            }
        }
    }
    /// <summary>
    /// 装弹
    /// </summary>
    private void Reload(Prop[] Bullets)
    {
        if (Bullets != null)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                bulletIndex = 0;
                //按照对应的弹夹中子弹的顺序从背包依次减少子弹数量
                
            }
        }
        else
        {
            return;
        }
        
    }
    /// <summary>
    /// 射击
    /// </summary>
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (gun != null)
            {
                PlayAnimation("isAttack", "attack");
                if (bulletIndex > 5)
                {
                    return;
                }
                else
                {
                    currentBullet = GameSystem.BulletSystem.GetBullet(bulletIndex, currentBullets);
                    //动态加载对应的子弹实例
                    //背包系统对应子弹数量减少
                    if (currentBullet == null)
                    {
                        Debug.Log("当前弹夹无子弹配置");
                    }
                    else
                    {
                        if(GameSystem.BackpackSystem.GetProp(currentBullet.propName) > 0)
                        {
                            GameSystem.BattleSystem.InstanceBullet(currentBullet.propName);
                            //Debug.Log(currentBullet.propName);
                            GameSystem.BackpackSystem.RemoveProp(currentBullet.propName, 1);
                        }
                        bulletIndex += 1;
                    }
                }
            }
            
        }
        
    }
    /// <summary>
    /// 射击锁定
    /// </summary>
    private void LockEmeny()
    {
        lockedEmeny=GameSystem.BattleSystem.ChangeEmeny(GameSystem.BattleSystem.GetEmeny());
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

    //-------------------------------------------------------
    /// <summary>
    /// 封装的播放动画
    /// </summary>
    /// <param name="boolName">状态传递变量</param>
    /// <param name="theAnimationName">动画名</param>
    private void PlayAnimation(string boolName, string theAnimationName)
    {
        animator.SetBool(boolName, true);
        animationState = boolName;
        animationName = theAnimationName;
    }
    /// <summary>
    /// 判断动画是否播放完毕并且切换状态
    /// </summary>
    /// <param name="theAnimator"></param>
    /// <param name="isBool">状态传递变量</param>
    /// <param name="animationName">动画名</param>
    private void PlayAnimationOver(Animator theAnimator,string isBool,string animationName)
    {
        //获取第0层的动画层
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if(info.normalizedTime >= 0.95f && info.IsName(animationName))
        {
            
            animator.SetBool(isBool, false);
           
        }
    }

}
namespace GameSystem
{
    public class Gun
    {
        public int maxBulletNumber;//最大子弹数
        public int GunState;//当前枪的状态
        public int GunDamage;//子弹伤害
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