using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystemInstance
{
    public class MenuSystemInstance : SystemInstance<MenuSystemInstance>
    {
        [Header("UI事件系统")]
        public EmptyStruct 一一一一一一一一一一;
        [System.Serializable]
        public class Setting
        {

        }
        public Setting setting;
        private GameObject mainUI;
        private GameObject bulletUI;
        //当前选中的子弹类型
        public PistolBullet selectPistolBullet;
        //当前选中的弹夹
        public Prop[] selectPistolBullets;

        private void Start()
        {
            mainUI = GameObject.Find("MainUI");
            bulletUI = mainUI.transform.GetChild(1).gameObject;
        }


        //子弹系统UI----------------------------------
        //呼出子弹UI界面
        public void OnBulletButtonDown()
        {
            bulletUI.SetActive(true);
        }
        public void ExitBulletButton()
        {//关闭UI界面
            bulletUI.SetActive(false);
        }
        public void SelectBullets()
        {//选择设置弹夹
            var buttton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            string s = buttton.name;
            GameObject PistolButton = bulletUI.transform.GetChild(0).gameObject;
            GameObject RifleButton = bulletUI.transform.GetChild(1).gameObject;
            GameObject PistolBullet01 = PistolButton.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
            GameObject PistolBullet02 = PistolButton.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject;
            GameObject PistolBullet03 = PistolButton.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject;
            GameObject RifleBullet01 = RifleButton.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;
            GameObject RifleBullet02 = RifleButton.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject;
            GameObject RifleBullet03 = RifleButton.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject;
            //Debug.Log(s);
            switch (s)
            {
                case "PistolBullets01":
                    PistolBullet01.SetActive(true);
                    PistolBullet02.SetActive(false);
                    PistolBullet03.SetActive(false);
                    selectPistolBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets01;
                    break;
                case "PistolBullets02":
                    PistolBullet01.SetActive(false);
                    PistolBullet02.SetActive(true);
                    PistolBullet03.SetActive(false);
                    selectPistolBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets02;
                    break;
                case "PistolBullets03":
                    PistolBullet01.SetActive(false);
                    PistolBullet02.SetActive(false);
                    PistolBullet03.SetActive(true);
                    selectPistolBullets = GameSystem.BulletSystem.Instance.setting.pistolBullets03;
                    break;
                case "RifleBullets01":
                    RifleBullet01.SetActive(true);
                    RifleBullet02.SetActive(false);
                    RifleBullet03.SetActive(false);
                    selectPistolBullets = GameSystem.BulletSystem.Instance.setting.rifleBullets01;
                    break;
                case "RifleBullets02":
                    RifleBullet01.SetActive(false);
                    RifleBullet02.SetActive(true);
                    RifleBullet03.SetActive(false);
                    selectPistolBullets = GameSystem.BulletSystem.Instance.setting.rifleBullets02;
                    break;
                case "RifleBullets03":
                    RifleBullet01.SetActive(false);
                    RifleBullet02.SetActive(false);
                    RifleBullet03.SetActive(true);
                    selectPistolBullets = GameSystem.BulletSystem.Instance.setting.rifleBullets03;
                    break;
                    
            }
        }
        public void SeleteBulletType()
        {//选择子弹类型，暂时只有手枪子弹，步枪子弹类型等图片出来再加上去
            var buttton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            string s = buttton.name;
            switch (s)
            {
                case "1":selectPistolBullet = PistolBullet.PistolBullet01.pistolBullet01;
                    break;
                case "2":selectPistolBullet = PistolBullet.PistolBullet02.pistolBullet02;
                    break;
                case "3":selectPistolBullet = PistolBullet.PistolBullet03.pistolBullet03;
                    break;
            }
        }
        public void SetPistolBullet()
        {//给弹夹设置子弹
            var buttton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            string s = buttton.name;
            switch (s)
            {
                case "1": GameSystem.BulletSystem.SetBullet(0, selectPistolBullet, selectPistolBullets); break;
                case "2": GameSystem.BulletSystem.SetBullet(1, selectPistolBullet, selectPistolBullets); break;
                case "3": GameSystem.BulletSystem.SetBullet(2, selectPistolBullet, selectPistolBullets); break;
                case "4": GameSystem.BulletSystem.SetBullet(3, selectPistolBullet, selectPistolBullets); break;
                case "5": GameSystem.BulletSystem.SetBullet(4, selectPistolBullet, selectPistolBullets); break;
                case "6": GameSystem.BulletSystem.SetBullet(5, selectPistolBullet, selectPistolBullets); break;
            }

        }



    }
}
namespace GameSystem
{
    public static class MenuSystem
    {
        private static GameSystemInstance.MenuSystemInstance Instance { get { return GameSystemInstance.MenuSystemInstance.Instance; } }
        private static GameSystemInstance.MenuSystemInstance.Setting Setting { get { return Instance.setting; } }
     
        



    }
}
