using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float EnemyHealth;
	public float EnemyDamage;
	public Rigidbody2D body;
	public float SomeDamage;

	public void TakeDamage(){
		EnemyHealth = EnemyHealth - SomeDamage;
	}
}
