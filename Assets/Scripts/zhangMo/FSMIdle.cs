// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMIdle : FSMstate {
	public FSMIdle(GameObject thisGameObj):base(thisGameObj)
	{
		enemyObject = thisGameObj;
	}
	//public List<FSMTransition> transitions;
	//public FSMTransition validTranstion;
	public override void onEnter()
	{
		transitions.Add(new TrIdle2Pat(this));
		Debug.Log("Enter Idle state.");
	}
	public override void onUpdate()
	{
		// 播放动画
		// test
		//Debug.Log("Now is Idle State. ");
		foreach (var trans in transitions)
		{
			if(trans.isValid())
			{
				validTranstion = trans;
				//Debug.Log(trans.name);
				break;
			}
		}
	}
	public override void onExit()
	{
		Debug.Log("Exit Idle State.");
		transitions.Clear();
	}	
}
