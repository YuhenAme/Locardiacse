using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMstate
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

	public List<FSMTransition> transitions;
	public FSMTransition validTranstion;
}

public class FSMTransition
{
	FSMstate activeState;
	FSMstate nextState;
	public virtual bool isValid(){ return false; }
	public FSMstate getNextState()
	{
		if(activeState.validTranstion != null)
			return nextState;
		return null;
	}
	public virtual void onTransition(){}

}

class FiniteStateMachine : MonoBehaviour
{
	//List<FSMstate> states;

	FSMstate initialState;

	FSMstate activeState;
	private void Start()
	{
		activeState = initialState;
	}
	private void Update()
	{	
		if(activeState.validTranstion.isValid())
		{
			FSMTransition validTranstion = activeState.validTranstion;
			activeState.onExit();
			activeState.validTranstion.getNextState();
			activeState.onEnter();
		}
		else
		{
			activeState.onUpdate();
		}
	}

}