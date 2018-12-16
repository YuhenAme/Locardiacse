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
		transitions.Add(new TrAny2Die(this));
		transitions.Add(new TrAwa2Atk(this));
		// 察觉到玩家，在这里输入玩家pos
	}
	public override void onUpdate()
	{
		Move(data.chaseTarget.position);
		// 检测玩家是否在影子中
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

	public override void Move(Vector3 target)
	{
		setSpeed();
		Debug.Log("move to player");
		enemyTrans.position = Vector3.MoveTowards(enemyTrans.position,new Vector3(target.x,enemyTrans.position.y,target.z),speed*Time.deltaTime);
	}
	public override void onExit()
	{

	}

	public void setSpeed()
	{
		speed = data.getSpeed();
	}
}
