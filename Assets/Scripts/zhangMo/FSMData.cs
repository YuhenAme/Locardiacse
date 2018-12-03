using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FSMData : MonoBehaviour
{// 数据类，存放敌人AI所享有的各种属性

	//_______________实例__________________

	public AudioClip audio;



	//________________属性_________________

	[Range(0,10)] public float speed;
	[Range(0,100)] public float life;
	[Range(0,100)] public float damage;
	[Range(0,10)] public float visualRange;

}
