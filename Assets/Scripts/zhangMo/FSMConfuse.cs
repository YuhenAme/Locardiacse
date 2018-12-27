using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMConfuse : FSMstate {
	// 一个用来表示追逐后玩家脱离视野时的状态
	public FSMConfuse(GameObject thisGameObj):base(thisGameObj)
	{
		enemyObject = thisGameObj;
	}

	public override void onEnter()
	{
		transitions.Add(new TrAny2Die(this));
		transitions.Add(new TrAny2Awa(this));
		// 丢失玩家后进入Patrol状态或者返回pos（TODO）
		transitions.Add(new TrCon2Pat(this));

	}
	private float timer = 0.0f;
	public override void onUpdate()
	{
		waitForSeconds(3.0f);
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
		transitions.Clear();
	}

	public void waitForSeconds(float target)
	{
		Debug.Log("人呢？");
		timer += Time.deltaTime;
		if(timer >= target)
		{
			data.isConfusedOver = true;
		}
		else data.isConfusedOver = false;
	}
}
