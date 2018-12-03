// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour {

	//List<FSMstate> states;

	public GameObject enemyObject;
	private Transform enemyTrans;
	FSMstate initialState;
	FSMstate activeState;
	private void Awake() {
		//enemyObject = this.gameObject.transform.parent.gameObject;
		initialState = new FSMIdle(enemyObject);
	}
	void Start()
	{
		//Debug.Log(initialState);
		activeState = initialState;
		activeState.onEnter();
	}
	private void Update()
	{	
		//Debug.Log(activeState);
		if(activeState.validTranstion!=null)
		{
			FSMTransition validTranstion = activeState.validTranstion;
			validTranstion.onTransition();
			activeState.onExit();
			activeState = activeState.validTranstion.getNextState();
			Debug.Log(activeState);
			activeState.onEnter();
		}
		else
		{
			activeState.onUpdate();
		}
	}
}
