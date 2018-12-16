using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAttack : FSMstate {
	public FSMAttack(GameObject thisGameObj):base(thisGameObj)
	{
		enemyObject = thisGameObj;
	}
	[SerializeField]
	private float speed;
	public override void onEnter()
	{
		
	}
	public override void onUpdate()
	{
		// 检测玩家
	}
	public override void onExit()
	{

	}

	void Attack()
	{
		
	}
}
