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
		transitions.Add(new TrAny2Awa(this));
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
		attackTypeJudger();
    }
	public override void onExit()
	{
		transitions.Clear();
	}

	public void nearAttack()
	{
		Debug.Log("近战攻击");
		// TODO 播放攻击动画
		data.isTimeToEnterAware = true;
	}

	public void remoteAttack()
	{
		Debug.Log("远程攻击");
		// TODO 播放攻击动画
		data.isTimeToEnterAware = true;
	}

	public void attackTypeJudger()
	{
		if(Vector3.Distance(enemyTrans.position,data.player.transform.position)<data.getAttackRange())
		{
			nearAttack();
		}
		else
		{
			remoteAttack();
		}
	}
}
