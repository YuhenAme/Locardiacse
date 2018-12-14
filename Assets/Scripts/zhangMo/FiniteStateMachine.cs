// Copyright (C) 2018 Memo游戏工作室 版权所有
// 创建标识： #DEVELOPER_NAME# #CREATE_DATE#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour {

	//List<FSMstate> states;

	public GameObject enemyObject;
	private Transform enemyTrans;
	private FSMData data;
	FSMstate initialState;
	FSMstate activeState;
	public string activeStateName;
	private void Awake() {
		//enemyObject = this.gameObject.transform.parent.gameObject;
		data = enemyObject.GetComponent<FSMData>();
		initialState = new FSMIdle(enemyObject);
	}
	void Start()
	{
		//Debug.Log(initialState);
		activeState = initialState;
		activeState.onEnter();
	}
	private void Update()
	{	
		activeStateName = activeState.ToString();
		OnDrawGizmos();
		//Debug.Log(activeState);
		if(activeState.validTranstion!=null)
		{
			FSMTransition validTranstion = activeState.validTranstion;
			validTranstion.onTransition();
			activeState.onExit();
			activeState = activeState.validTranstion.getNextState();
			//Debug.Log(activeState);
			activeState.onEnter();
		}
		else
		{
			activeState.onUpdate();
			activeState.DrawFieldOfView();
			//activeState.Look();
		}
	}

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{// hard to test this func because some reasons.
		if(other.transform.tag == "bullet")
		{
			switch(other.gameObject.GetComponent<BulletInstance>().GetType().Name)
			{
				case "test1": break;// Do Test1
				case "test2": break;// Do Test2
				case "test3": break;// Do test3
			}
		}
		if(other.transform.tag == "Player")
		{
			// Maybe it will hurt the player
		}
	}
	private void OnDrawGizmos()
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
			float x = data.getVisualRange() * Mathf.Cos(theta);
            float z = data.getVisualRange()  * Mathf.Sin(theta);
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
	}
}
