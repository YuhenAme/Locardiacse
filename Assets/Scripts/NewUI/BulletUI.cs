using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletUI : BaseUI {

    GameObject bulletButton;
    GameObject bulletUI;
    //当前选中的弹夹,初始为弹夹1
    public Prop[] selectPistolBullets = new Prop[6];
    public Prop[] selectRifleBullets;
    public PistolBullet selectPistolBullet;
    public RifleBullet selectRifleBullet;
    int index;

    //new------------
    private Button btn_exit;
    private Button btn_reset;
    private Button btn_confirm;
    private Button btn_pistol;
    private Button btn_rifle;
    private Button btn_bullet1;
    private Button btn_bullet2;
    private Button btn_bullet3;
    private Button btn_chain1;
    private Button btn_chain2;
    private Button btn_chain3;

    private void Start()
    {
        btn_exit = GameSystem.MenuSystem.FindChildByName(gameObject, "ExitButton").GetComponent<Button>();
        btn_reset = GameSystem.MenuSystem.FindChildByName(gameObject, "ResetButton").GetComponent<Button>();
        btn_confirm = GameSystem.MenuSystem.FindChildByName(gameObject, "ConfirmButton").GetComponent<Button>();
        btn_pistol = GameSystem.MenuSystem.FindChildByName(gameObject, "PistolButton").GetComponent<Button>();
        btn_rifle  = GameSystem.MenuSystem.FindChildByName(gameObject, "RifleButton").GetComponent<Button>();
        btn_bullet1 = GameSystem.MenuSystem.FindChildByName(gameObject, "1").GetComponent<Button>();
        btn_bullet2 = GameSystem.MenuSystem.FindChildByName(gameObject, "2").GetComponent<Button>();
        btn_bullet3 = GameSystem.MenuSystem.FindChildByName(gameObject, "3").GetComponent<Button>();
        btn_chain1  = GameSystem.MenuSystem.FindChildByName(gameObject, "PistolBullets1").GetComponent<Button>();
        btn_chain2 = GameSystem.MenuSystem.FindChildByName(gameObject, "PistolBullets2").GetComponent<Button>();
        btn_chain3 = GameSystem.MenuSystem.FindChildByName(gameObject, "PistolBullets3").GetComponent<Button>();
        //selectPistolBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets01;
        btn_exit.onClick.AddListener(Exit);
        btn_reset.onClick.AddListener(ResetButtonDown);
        btn_confirm.onClick.AddListener(ConfirmButtonDown);
        btn_pistol.onClick.AddListener(PistolButtonDown);
        btn_rifle.onClick.AddListener(RifleButtonDown);
        btn_bullet1.onClick.AddListener(PistolBulletConfigure);
        btn_bullet2.onClick.AddListener(PistolBulletConfigure);
        btn_bullet3.onClick.AddListener(PistolBulletConfigure);
        btn_chain1.onClick.AddListener(PistolBulletConfigure);
        btn_chain2.onClick.AddListener(PistolBulletConfigure);
        btn_chain3.onClick.AddListener(PistolBulletConfigure);
    }

    private void Exit()
    {
        gameObject.GetComponent<BulletUI>().CloseUI();
    }

    //选择设置手枪弹夹
    public void PistolButtonDown()
    {
        GameObject pistolConfigure = gameObject.transform.GetChild(4).gameObject;
        GameObject rifleConfigure = gameObject.transform.GetChild(6).gameObject;
        pistolConfigure.SetActive(true);
        rifleConfigure.SetActive(false);
    }
    //选择设置步枪弹夹
    public void RifleButtonDown()
    {
        GameObject pistolConfigure = gameObject.transform.GetChild(4).gameObject;
        GameObject rifleConfigure = gameObject.transform.GetChild(6).gameObject;
        pistolConfigure.SetActive(false);
        rifleConfigure.SetActive(true);
    }
    //设置手枪弹夹
    public void PistolBulletConfigure()
    {
        //找到弹链
        GameObject bulletChain1 = gameObject.transform.GetChild(4).GetChild(1).GetChild(1).gameObject;
        GameObject bulletChain2 = gameObject.transform.GetChild(4).GetChild(2).GetChild(1).gameObject;
        GameObject bulletChain3 = gameObject.transform.GetChild(4).GetChild(3).GetChild(1).gameObject;

        //根据点击的弹夹按钮显示对应的弹链
        var buttton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        string s = buttton.name;
        switch (s)
        {
            case "PistolBullets1":
                bulletChain1.SetActive(true);
                bulletChain2.SetActive(false);
                bulletChain3.SetActive(false);
                //selectPistolBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets01;
                break;
            case "PistolBullets2":
                bulletChain1.SetActive(false);
                bulletChain2.SetActive(true);
                bulletChain3.SetActive(false);
                //selectPistolBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets02;
                break;
            case "PistolBullets3":
                bulletChain1.SetActive(false);
                bulletChain2.SetActive(false);
                bulletChain3.SetActive(true);
                //selectPistolBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets03;
                break;
        }

        if (index <= 5)
        {
            //点击子弹上膛
            var buttton2 = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            string s2 = buttton.name;
            switch (s2)
            {
                case "1":
                    selectPistolBullet = PistolBullet.PistolBullet01.pistolBullet01;
                    GameSystem.BulletSystem.SetBullet(index, selectPistolBullet, selectPistolBullets);
                    index++;
                    break;
                case "2":
                    selectPistolBullet = PistolBullet.PistolBullet02.pistolBullet02;
                    GameSystem.BulletSystem.SetBullet(index, selectPistolBullet, selectPistolBullets);
                    index++;
                    break;
                case "3":
                    selectPistolBullet = PistolBullet.PistolBullet03.pistolBullet03;
                    GameSystem.BulletSystem.SetBullet(index, selectPistolBullet, selectPistolBullets);
                    index++;
                    break;
            }
        }
    
    }
    //确认
    public void ConfirmButtonDown()
    {
        var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        GameObject chains = button.transform.parent.parent.gameObject;
        switch (chains.name)
        {
            case "PistolBullets1":
                GameSystem.BulletSystem.Instance.setting.pistolBullets01 = selectPistolBullets;
                index = 0;
                break;
            case "PistolBullets2":
                GameSystem.BulletSystem.Instance.setting.pistolBullets02 = selectPistolBullets;
                index = 0;
                break;
            case "PistolBullets3":
                GameSystem.BulletSystem.Instance.setting.pistolBullets03 = selectPistolBullets;
                index = 0;
                break;
        }
    }
    //重置
    public void ResetButtonDown()
    {
        selectPistolBullets = null;
        index = 0;
        selectRifleBullets = null;
        index = 0;
    }

}
