using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrAwa2Con : FSMTransition {

	public TrAwa2Con(FSMstate nowState):base(nowState){ }

	public override bool isValid()
	{
		if(data.isTimeToQuitAware) return true;
		return false;
	}
	public override void onTransition()
	{
		data.isTimeToQuitAware = false;
		FSMConfuse newState = new FSMConfuse(activeState.getEnemyObject());
		SetNextState(newState);
	}
}
