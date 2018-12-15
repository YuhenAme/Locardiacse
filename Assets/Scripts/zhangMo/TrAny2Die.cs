using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 反正哪个状态都会死，不如any to die 好了。
public class TrAny2Die : FSMTransition {

	public TrAny2Die(FSMstate nowState):base(nowState){ }

	public override bool isValid()
	{
		if(activeState.GetData().isDead)
		{
			Debug.Log("A wo si le");
			return true;
		}
		return false;
	}

	public override void onTransition()
	{
		FSMDie newState = new FSMDie(activeState.getEnemyObject());
		SetNextState(newState);
	}

}
