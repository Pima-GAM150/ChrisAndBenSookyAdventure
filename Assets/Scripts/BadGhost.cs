using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGhost : Enemy {
	private float movingspeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){

		transform.right = Playertochase.position - transform.position;

	transform.position = Vector2.MoveTowards(transform.position, Playertochase.position,movingspeed* Time.deltaTime);

		
	}
}
