using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 战斗系统
/// </summary>
public class BattleSystem : MonoBehaviour {

    //敌人的list
    public List<GameObject> emenyList;
    public GameObject lockedEmeny;

    private void Start()
    {
        emenyList = new List<GameObject>();
    }
    /// <summary>
    /// 将敌人加入敌人list中
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetEmeny()
    {
        GameObject[] emenys = GameObject.FindGameObjectsWithTag("Emeny");
        foreach(GameObject emeny in emenys)
        {
            Vector2 emenyPos = Camera.main.WorldToViewportPoint(emeny.transform.position);
            if (emenyPos.x < 1 && emenyPos.x > 0 && emenyPos.y > 0 && emenyPos.y < 1)
            {
                if (!emenyList.Contains(emeny))
                {
                    emenyList.Add(emeny);
                }
            }
            else
            {
                if (emenyList.Contains(emeny))
                {
                    emenyList.Remove(emeny);
                }
            }
        }
        return emenyList;
    }
    /// <summary>
    /// 索敌机制,返回一个锁定的敌人
    /// </summary>
    /// <param name="emenys">敌人list</param>
    /// <returns></returns>
    public GameObject ChangeEmeny(List<GameObject> emenys)
    {

        return lockedEmeny;
    }
}
