using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMstate : MonoBehaviour
{
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
		Debug.Log("To get next.");
		if(activeState.validTranstion != null)
			return nextState;
		return null;
	}
	public virtual void onTransition(){}
	public void SetNextState(FSMstate tempState)
	{
		nextState = tempState;
	}
}
