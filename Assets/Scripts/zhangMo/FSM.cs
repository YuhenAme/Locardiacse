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
	}
	
	/// <summary>
	/// 退出状态时执行的工作
	/// </summary>
	public virtual void onExit(){}

	/// <summary>
	/// 状态转换间的连接
	/// </summary>
	public List<FSMTransition> transitions = new List<FSMTransition>();
	
	public FSMTransition validTranstion;
	public GameObject getEnemyObject()
	{
		return enemyObject;
	}
	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		//用于受伤判定
	}

	/* private void OnDrawGizmos()
	{
		if(enemyTrans == null) return;

		Matrix4x4 defaultMatrix = Gizmos.matrix;
		Gizmos.matrix = enemyTrans.localToWorldMatrix;

		Color defaultColor = Gizmos.color;	
		Gizmos.color = Color.green;

		Vector3 beginPoint = Vector3.zero;
		Vector3 firstPoint = Vector3.zero;

		for(float theta = 0;theta <Mathf.PI;theta += 0.0001f)
		{
			float x = data.visualRange * Mathf.Cos(theta);
            float z =data.visualRange  * Mathf.Sin(theta);
            Vector3 endPoint = new Vector3(x, 0, z);
        	if (theta == 0)
            {
                firstPoint = endPoint;
            }
            else
            {
                Gizmos.DrawLine(beginPoint, endPoint);
            }
            beginPoint = endPoint;
		}
		// 绘制最后一条线段
    	Gizmos.DrawLine(firstPoint, beginPoint);

        // 恢复默认颜色
        Gizmos.color = defaultColor;

        // 恢复默认矩阵
        Gizmos.matrix = defaultMatrix;

	}*/

	/*void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(enemyTrans.position, data.visualRange);
    } */

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

