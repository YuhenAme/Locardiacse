using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrAwa2Con : FSMTransition {

	public TrAwa2Con(FSMstate nowState):base(nowState){ }

	public override bool isValid()
	{
		if(data.chaseTarget == null) return true;
		return false;
	}
	public override void onTransition()
	{
		FSMConfuse newState = new FSMConfuse(activeState.getEnemyObject());
		SetNextState(newState);
	}
}
