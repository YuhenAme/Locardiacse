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
        ////改变敌人的方向
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //if (player.transform.position.x < enemyTrans.position.x)
        //    enemyTrans.localScale = new Vector3(-1, 1, 1);
        //else
        //    enemyTrans.localScale = new Vector3(1, 1, 1);
        //enemyObject.GetComponent<Animator>().SetBool("isMove", true);
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
