// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrIdle2Pat : FSMTransition {

	public TrIdle2Pat(FSMstate nowState):base(nowState){ }
	private float sleepTime = 5.0f;
	private float timer = 0.0f;
	public override bool isValid()
	{
		// 转换条件
		/* if(Input.GetKeyDown(KeyCode.P))
		{// 测试用
			Debug.Log("in");
			
			return true;
		}*/
		// 一个计时器，当计时结束进入Pat状态
		if(timer < sleepTime)
		{
			timer += Time.deltaTime;
			return false;
		}
		else if(timer >= sleepTime)
		{
			timer = 0;
			return true;
		}
		else return false;
	}

	public override void onTransition()
	{
		// 设置对应状态中数据
		SetNextState(new FSMPatrol(activeState.getEnemyObject()));
	}

}
