using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGhost : Enemy {
	private float movingspeed = 1;
	private float distBetween;
	
	private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
		originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update(){
		     
		distBetween = Vector3.Distance(Playertochase.position, transform.position);

		if(distBetween < 5f){
        transform.right = Playertochase.position - transform.position;

		transform.position = Vector2.MoveTowards(transform.position, Playertochase.position,movingspeed* Time.deltaTime);
            }	
         else{
         	transform.rotation = originalRotation;
         }   
        }
}
