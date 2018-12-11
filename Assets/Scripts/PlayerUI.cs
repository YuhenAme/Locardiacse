using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    GameObject playerHP;
    GameObject playerBullet;
    GameObject mainUI;
    GameObject player;
    // Use this for initialization
    void Start () {
        mainUI = GameObject.Find("MainUI");
        playerHP = mainUI.transform.GetChild(4).transform.GetChild(0).gameObject;
        playerBullet = mainUI.transform.GetChild(4).transform.GetChild(1).gameObject;
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //playerHP.GetComponent<Text>().text = "HP: " + player.GetComponent<PlayController>().hp;
        //playerBullet.GetComponent<Text>().text = "Bullet: " + playerBullet.GetComponent<PlayController>().currentBullet.propName;
        //Debug.Log(GameSystem.BulletSystem.GetBullet(0, playerBullet.GetComponent<PlayController>().currentBullets).propName);
	}
}
