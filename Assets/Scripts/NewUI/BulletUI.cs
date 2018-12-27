using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUI : MonoBehaviour {

    GameObject bulletButton;
    GameObject bulletUI;
    //当前选中的弹夹,初始为弹夹1
    public Prop[] selectPistolBullets = new Prop[6];
    public Prop[] selectRifleBullets;
    public PistolBullet selectPistolBullet;
    public RifleBullet selectRifleBullet;
    int index;

    private void Start()
    {
        bulletButton = GameObject.Find("MainUI").transform.GetChild(0).gameObject;
        bulletUI = GameObject.Find("MainUI").transform.GetChild(1).gameObject;
        //selectPistolBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets01;
    }

    public void BulletButtonDown()
    {
        bulletUI.SetActive(true);
    }
	public void ExitButtonDown()
    {
        bulletUI.SetActive(false);
    }

    //选择设置手枪弹夹
    public void PistolButtonDown()
    {
        GameObject pistolConfigure = bulletUI.transform.GetChild(4).gameObject;
        GameObject rifleConfigure = bulletUI.transform.GetChild(6).gameObject;
        pistolConfigure.SetActive(true);
        rifleConfigure.SetActive(false);
    }
    //选择设置步枪弹夹
    public void RifleButtonDown()
    {
        GameObject pistolConfigure = bulletUI.transform.GetChild(4).gameObject;
        GameObject rifleConfigure = bulletUI.transform.GetChild(6).gameObject;
        pistolConfigure.SetActive(false);
        rifleConfigure.SetActive(true);
    }
    //设置手枪弹夹
    public void PistolBulletConfigure()
    {
        //找到弹链
        GameObject bulletChain1 = bulletUI.transform.GetChild(4).GetChild(1).GetChild(1).gameObject;
        GameObject bulletChain2 = bulletUI.transform.GetChild(4).GetChild(2).GetChild(1).gameObject;
        GameObject bulletChain3 = bulletUI.transform.GetChild(4).GetChild(3).GetChild(1).gameObject;

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
