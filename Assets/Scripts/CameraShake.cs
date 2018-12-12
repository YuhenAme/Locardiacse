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

    private Vector3 cameraPos;//摄像机位置
    // Use this for initialization
    void Start () {
        cameraPos = transform.position;
	}

    private void LateUpdate()
    {
        if (startShake)
        {
            transform.localPosition = cameraPos + Random.insideUnitSphere * quake;
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
    public static void Shake(float a,float b)
    {
        seconds = a;
        started = true;
        startShake = true;
        quake = b;
    }
    IEnumerator WaitForSecond(float a)
    {
        yield return new WaitForSeconds(a);
        startShake = false;
        transform.localPosition = cameraPos;
    }

}
