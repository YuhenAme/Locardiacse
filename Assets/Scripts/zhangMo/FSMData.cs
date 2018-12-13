using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FSMData : MonoBehaviour
{// 数据类，存放敌人AI所享有的各种属性

	//_______________实例__________________

	public AudioClip[] audio;
	public Animator animator;


	//________________属性_________________

	[SerializeField]
	[Range(0,10)] private float speed;
	[SerializeField]
	[Range(0,100)] private float life;
	[SerializeField]
	[Range(0,100)] private float damage;
	[SerializeField]
	[Range(0,10)] private float visualRange;
	[SerializeField]
	[Range(0,10)] private float patrolRange;

	//________________状态_________________
	public bool isFacingLeft;

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

	public void setVisualRange(float input)
	{
		visualRange = input;
	}

	public float getVisualRange()
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

}
