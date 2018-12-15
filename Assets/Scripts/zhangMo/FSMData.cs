using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FSMData : MonoBehaviour
{// 数据类，存放敌人AI所享有的各种属性

	//_______________实例__________________

	public AudioClip[] audio;
	public Animator animator;
	public Transform chaseTarget;
	public GameObject player;

	//________________属性_________________

	[SerializeField] [Range(0,10)] private float speed;
	[SerializeField] [Range(0,100)] private float life;
	[SerializeField] [Range(0,100)] private float damage;
	[SerializeField] [Range(0,10)] private int visualRange;
	[SerializeField] [Range(0,10)] private float patrolRange;
	[SerializeField] [Range(0,120)] private float lookAngle;
	public float lookAccurate = 30;
	[SerializeField] [Range(0,360)] private float radioColdDown;
	//________________状态_________________
	//public bool isFacingLeft;
	public bool isDead = false;
	//________________初始化________________
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void setAnimator(Animator input)
	{
		animator = input;
	}

	public Animator getAnimator()
	{
		return animator;
	}

	public void setSpeed(float input)
	{
		speed = input;
	}

	public float getSpeed()
	{
		return speed;
	}

	public void setLife(float input)
	{
		life = input;
	}

	public float getLife()
	{
		return life;
	}

	public void setDamage(float input)
	{
		damage = input;
	}

	public float getDamage()
	{
		return damage;
	}

	public void setVisualRange(int input)
	{
		visualRange = input;
	}

	public int getVisualRange()
	{
		return visualRange;
	}
	public void setPatrolRange(float input)
	{
		patrolRange = input;
	}

	public float getPatrolRange()
	{
		return patrolRange;
	}

	public void setRadioColdDown(float input)
	{
		radioColdDown = input;
	}

	public float getRadioColdDown()
	{
		return radioColdDown;
	}

	public void setLookAngle(float input)
	{
		lookAngle = input;
	}

	public float getLookAngle()
	{
		return lookAngle;
	}


}
