using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FSMPatrol : FSMstate {
	public bool isfacingLeft;
	private float patrolRange;
	private bool isArriveTarget = false;
	Vector3 targetPos;
	public FSMPatrol(GameObject thisGameObj):base(thisGameObj)
	{
		enemyObject = thisGameObj;
	}
	[SerializeField]
	private float speed = 3.0f;
	public override void onEnter()
	{
		//Debug.Log("Enter Patrol state.");
		enemyTrans = enemyObject.transform;
		data = enemyObject.GetComponent<FSMData>();
		isfacingLeft = data.isFacingLeft;
		patrolRange = data.getPatrolRange();
		targetPos = new Vector3(enemyTrans.position.x - patrolRange,enemyTrans.position.y,enemyTrans.position.z);
		transitions.Add(new TrAny2Die(this));
		transitions.Add(new TrAny2Awa(this));
	}
	public override void onUpdate()
	{
		//enemyTrans.Translate(Vector3.left*Time.deltaTime*speed);
		Move();
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
		//Debug.Log("Exit Patrol state");
		transitions.Clear();
	}

	public override void Move()
	{
		Vector3 scale = enemyTrans.localScale;
		//Debug.Log("Target:"+targetPos);
		if(!isArriveTarget)
		{
			enemyTrans.Translate(Vector3.left * speed * Time.deltaTime,Space.World);
			
			if(Mathf.Abs(enemyTrans.position.x - targetPos.x)<0.1f)
			{
				//Debug.Log("Change Direction");
				targetPos = new Vector3(enemyTrans.position.x + 2*patrolRange,enemyTrans.position.y,enemyTrans.position.z);
				scale.x *= -1;
				isArriveTarget = true;
			}
		}
		else
		{
			enemyTrans.Translate(Vector3.right * speed * Time.deltaTime,Space.World);
			if(Mathf.Abs(enemyTrans.position.x - targetPos.x)<0.1f)
			{
				//Debug.Log("Change Direction");
				scale.x *= -1;
				targetPos = new Vector3(enemyTrans.position.x - 2*patrolRange,enemyTrans.position.y,enemyTrans.position.z);
				isArriveTarget = false;
			}
		}
		enemyTrans.localScale = scale;
	}

	/* IEnumerator FindPlayer()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		yield return null;
	} */
	public bool RandomCreator()
	{
		System.Random rd = new System.Random();
		int result = rd.Next(1,10);
		if(result%2 == 0)
			return true;
		else return false;
	}

}
