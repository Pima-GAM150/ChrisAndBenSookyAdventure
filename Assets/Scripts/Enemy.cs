using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float EnemyHealth;
	public float EnemyDamage;
	public Rigidbody2D body;
	public float SomeDamage;
	public Transform Playertochase;
	public float MoveSpeed;
	public GameObject self;


	public void TakeDamage(){
		EnemyHealth = EnemyHealth - SomeDamage;
	}

	public void Death(){
		Destroy(self);
	}
	

}
