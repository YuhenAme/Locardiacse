// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour {

	//List<FSMstate> states;

	FSMstate initialState = new FSMIdle();

	FSMstate activeState;
	private void Start()
	{
		activeState = initialState;
		activeState.onEnter();
	}
	private void Update()
	{	
		//Debug.Log(activeState.validTranstion.name);
		if(activeState.validTranstion!=null)
		{
			FSMTransition validTranstion = activeState.validTranstion;
			activeState.onExit();
			activeState = activeState.validTranstion.getNextState();
			activeState.onEnter();
		}
		else
		{
			activeState.onUpdate();
		}
	}
}
