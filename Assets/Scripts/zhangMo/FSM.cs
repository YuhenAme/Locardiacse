using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMstate
{
	protected GameObject enemyObject;
	protected Transform enemyTrans;
	protected FSMData data;
	public FSMstate(GameObject thisGameObj)
	{
		enemyObject = thisGameObj;
		enemyTrans = thisGameObj.GetComponent<Transform>();
		data = enemyObject.GetComponent<FSMData>();
	}
	/// <summary>
	/// 进入某状态时的初始化工作
	/// </summary>
	public virtual void onEnter(){}

	/// <summary>
	/// 在某状态中反复执行的工作，等同于Update
	/// </summary>
	public virtual void onUpdate()
	{
		//OnDrawGizmos();
		//Look();
	}
	
	/// <summary>
	/// 退出状态时执行的工作
	/// </summary>
	public virtual void onExit(){}

	/// <summary>
	/// 状态转换间的连接
	/// </summary>
	public List<FSMTransition> transitions = new List<FSMTransition>();

	/* public bool Look()
	{
		Debug.Log("search");
		var thisData = data;
		if(LookAround(enemyTrans,Quaternion.identity,Color.green,data))
		{
			return true;
		}
		float subAngle = (data.getLookAngle() / 2) / data.lookAccurate;
		for (int i = 0; i < data.lookAccurate; i++)
        {
            if (LookAround(enemyTrans, Quaternion.Euler(0, -1 * subAngle * (i + 1), 0), Color.green,data) 
                || LookAround(enemyTrans, Quaternion.Euler(0, subAngle * (i + 1), 0), Color.green,data))
                return true;
        }
		return false;
	}

	static public bool LookAround(Transform enemyTrans,Quaternion eulerAnger,Color DebugColor,FSMData data)
	{
		Debug.DrawRay(enemyTrans.position,eulerAnger * enemyTrans.forward.normalized * data.getVisualRange(), DebugColor); 
		RaycastHit hit;
		if(Physics.Raycast(enemyTrans.position, eulerAnger * enemyTrans.forward, out hit, data.getVisualRange()) && hit.collider.CompareTag("Player"))
		{
            data.chaseTarget = hit.transform;
            return true;
		}
		return false;
	} */

	public void DrawFieldOfView()
	{
		// 获得最左边那条射线的向量，相对正前方，角度是-45
        Vector3 forward_left = Quaternion.Euler(0, 0, -data.getLookAngle()) * -new Vector3(enemyTrans.localScale.x/Mathf.Abs(enemyTrans.localScale.x),0,0) * data.getVisualRange();
		for(int i = 0;i <= data.lookAccurate;i++)
		{
			 // 每条射线都在forward_left的基础上偏转一点，最后一个正好偏转90度到视线最右侧
            Vector3 v = Quaternion.Euler(0, 0, (90.0f/data.lookAccurate) * i) * forward_left;
            // Player位置加v，就是射线终点pos
            Vector3 pos = enemyTrans.position + v;
            // 从玩家位置到pos画线段，只会在编辑器里看到
            Debug.DrawLine(enemyTrans.position, pos, Color.red);
		}
	}
	public FSMTransition validTranstion;
	public GameObject getEnemyObject()
	{
		return enemyObject;
	}

	
	public virtual void Move() {}
	public virtual void Move(Vector3 targetPos) {}
}

public class FSMTransition
{
	public FSMTransition(FSMstate nowState)
	{
		activeState = nowState;
	}
	// 当前状态
	protected FSMstate activeState;
	// 目标状态
	public FSMstate nextState;
	public virtual bool isValid(){ return false; }
	public FSMstate getNextState()
	{
		//Debug.Log("To get next.");
		if(activeState.validTranstion != null)
		{
			//Debug.Log("return the next state!");
			return nextState;
		}

		return null;
	}
	public virtual void onTransition(){}
	public void SetNextState(FSMstate tempState)
	{
		nextState = tempState;
	}
}

