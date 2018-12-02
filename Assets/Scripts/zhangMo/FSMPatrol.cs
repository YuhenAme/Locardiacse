using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMPatrol : FSMstate {

	public FSMPatrol(GameObject thisGameObj):base(thisGameObj)
	{
		enemyObject = thisGameObj;
	}
	[SerializeField]
	private float speed = 3.0f;
	public override void onEnter()
	{
		Debug.Log("Enter Patrol state.");
		enemyTrans = enemyObject.transform;
	}
	public override void onUpdate()
	{
		//enemyTrans.Translate(Vector3.left*Time.deltaTime*speed);
	}
	public override void onExit()
	{
		Debug.Log("Exit Patrol state");
	}


}
