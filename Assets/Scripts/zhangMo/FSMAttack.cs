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
        transitions.Add(new TrAny2Die(this));
	}
	public override void onUpdate()
	{
        // 检测玩家
        foreach (var trans in transitions)
        {
            if (trans.isValid())
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

	void Attack()
	{
		
	}
}
