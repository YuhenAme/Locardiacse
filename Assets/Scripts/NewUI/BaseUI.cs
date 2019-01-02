using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 所有UI的基类
/// </summary>
public abstract class BaseUI : MonoBehaviour {

    public void OpenUI()
    {
        gameObject.SetActive(true);
    }
    public void CloseUI()
    {
        gameObject.SetActive(false);
    }
	
}
public enum UIType
{
    BulletUI,BackpackUI,GamingUI,
}
