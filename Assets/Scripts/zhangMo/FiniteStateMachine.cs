// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour {

	//List<FSMstate> states;

	public GameObject enemyObject;
	private Transform enemyTrans;
	private FSMData data;
	FSMstate initialState;
	FSMstate activeState;
	public string activeStateName;
	private void Awake() {
		//enemyObject = this.gameObject.transform.parent.gameObject;
		data = enemyObject.GetComponent<FSMData>();
		initialState = new FSMIdle(enemyObject);
	}
	void Start()
	{
		//Debug.Log(initialState);
		activeState = initialState;
		activeState.onEnter();
		StartCoroutine("FindPlayerByRadio");
	}
	private void Update()
	{	
		activeStateName = activeState.ToString();
		if(activeState.validTranstion!=null)
		{
			FSMTransition validTranstion = activeState.validTranstion;
			validTranstion.onTransition();
			activeState.onExit();
			activeState = activeState.validTranstion.getNextState();
			activeState.onEnter();
		}
		else
		{
			activeState.onUpdate();
			activeState.DrawFieldOfView();
			activeState.CheckLife();
		}
	}

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{// hard to test this func because some reasons.
		if(other.transform.tag == "bullet")
		{
			switch(other.gameObject.GetComponent<BulletInstance>().GetType().Name)
			{
				case "test1": break;// Do Test1
				case "test2": break;// Do Test2
				case "test3": break;// Do test3
			}
		}
		if(other.transform.tag == "Player")
		{
			// Maybe it will hurt the player
		}
	}

	IEnumerator FindPlayerByRadio()
	{
		int index = 0;
		while(true)
		{
			if(index == 0)
			{
				index++;
				yield return new WaitForSeconds(data.getRadioColdDown());
			}
			else
			{
				Debug.Log("Radio to find the pos of player");
				data.chaseTarget = data.player.transform;
				yield return new WaitForSeconds(data.getRadioColdDown());
			}
		}
		yield return null;
	}
}
