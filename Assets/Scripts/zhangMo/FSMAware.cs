using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMAware : FSMstate {
	public FSMAware(GameObject thisGameObj):base(thisGameObj)
	{
		enemyObject = thisGameObj;
	}
	[SerializeField]
	private float speed;
	public override void onEnter()
	{
		// 察觉到玩家，在这里输入玩家pos
	}
	public override void onUpdate()
	{
		// 检测玩家是否在影子中
			
	}
	public override void onExit()
	{

	}
}
