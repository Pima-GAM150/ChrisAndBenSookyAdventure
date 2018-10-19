using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {
	public GameObject[] Levels;
	private float Randomchoice;
	private int Intchoice;
	
	void Start () {
		Randomchoice = Random.Range(1f,10f);
		if( Randomchoice < 5){
			Intchoice = 0;
		}
		else {
			Intchoice = 1;
		}
		Levels[Intchoice].SetActive(true);
		print(Randomchoice);
	}
	
	
}
