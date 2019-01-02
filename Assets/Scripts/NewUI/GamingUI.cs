using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 游戏中的UI
/// </summary>
public class GamingUI : BaseUI {

    private Button btn_backpack;
    private Button btn_bullet;

    private void Awake()
    {
        btn_backpack = GameSystem.MenuSystem.FindChildByName(gameObject, "BackpackButton").GetComponent<Button>();
        btn_bullet = GameSystem.MenuSystem.FindChildByName(gameObject, "BulletButton").GetComponent<Button>();
        btn_backpack.onClick.AddListener(BackpackButtonDown);
        btn_bullet.onClick.AddListener(BulletButtonDown);
    }

    private void BackpackButtonDown()
    {
        GameSystem.MenuSystem.OpenNormalUI(UIType.BackpackUI);
    }
    private void BulletButtonDown()
    {
        GameSystem.MenuSystem.OpenNormalUI(UIType.BulletUI);
    }
}
