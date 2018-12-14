using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 摄像机震动
/// </summary>
public class CameraShake : MonoBehaviour {
    public static bool startShake = false;  //camera是否开始震动
    public static float seconds = 0f;    //震动持续秒数
    public static bool started = false;    //是否已经开始震动
    public static float quake = 0.2f;       //震动系数
    public static CameraShake TheCameraShake
    {
        get
        {
            return GameObject.Find("BackgroundCamera").GetComponent<CameraShake>();
        }
    }

    private  Vector3 cameraPos;//摄像机位置
    private  GameObject player;
    private  Vector3 playerPos;//玩家位置
    private List<GameObject> emenys;//敌人的列表
    // Use this for initialization
    void Start () {
        //cameraPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void LateUpdate()
    {
        Debug.Log(cameraPos);
        if (startShake)
        {
            transform.localPosition = cameraPos + Random.insideUnitSphere * quake;

            player.transform.localPosition = playerPos + Random.insideUnitSphere * quake;
            //foreach(GameObject emeny in emenys)
            //{
            //    emeny.transform.localPosition = 
            //}
        }
        if (started)
        {
            
            StartCoroutine(WaitForSecond(seconds));
            started = false;
        }
        
    }
    /// <summary>
    /// 外部调用的摄像机震动
    /// </summary>
    /// <param name="a">震动时间</param>
    /// <param name="b">震动幅度</param>
    public  void Shake(float a,float b)
    {
        seconds = a;
        started = true;
        startShake = true;
        quake = b;
        GetObjectPosition();
        
    }
    IEnumerator WaitForSecond(float a)
    {
        yield return new WaitForSeconds(a);
        startShake = false;
        transform.localPosition = cameraPos;
        player.transform.localPosition = playerPos;
        emenys = GameSystem.BattleSystem.GetEmeny();
    }
    /// <summary>
    /// 记录震动前的物体的位置
    /// </summary>
    private void GetObjectPosition()
    {
        cameraPos = transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        
    }
}
