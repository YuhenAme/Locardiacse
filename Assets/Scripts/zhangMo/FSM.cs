using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMstate
{
	protected GameObject enemyObject;
	protected Transform enemyTrans;
	public FSMstate(GameObject thisGameObj)
	{
		enemyObject = thisGameObj;
	}
	/// <summary>
	/// 进入某状态时的初始化工作
	/// </summary>
	public virtual void onEnter(){}

	/// <summary>
	/// 在某状态中反复执行的工作，等同于Update
	/// </summary>
	public virtual void onUpdate(){}
	
	/// <summary>
	/// 退出状态时执行的工作
	/// </summary>
	public virtual void onExit(){}

	/// <summary>
	/// 状态转换间的连接
	/// </summary>
	public List<FSMTransition> transitions = new List<FSMTransition>();
	
	public FSMTransition validTranstion;
	public GameObject getEnemyObject()
	{
		return enemyObject;
	}
	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		//用于受伤判定
	}
}

public class FSMTransition
{
	public FSMTransition(FSMstate nowState)
	{
		activeState = nowState;
	}
	// 当前状态
	protected FSMstate activeState;
	// 目标状态
	public FSMstate nextState;
	public virtual bool isValid(){ return false; }
	public FSMstate getNextState()
	{
		//Debug.Log("To get next.");
		if(activeState.validTranstion != null)
		{
			//Debug.Log("return the next state!");
			return nextState;
		}

		return null;
	}
	public virtual void onTransition(){}
	public void SetNextState(FSMstate tempState)
	{
		nextState = tempState;
	}
}
