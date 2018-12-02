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
		
	}
	public override void onUpdate()
	{
		
	}
	public override void onExit()
	{

	}
}
