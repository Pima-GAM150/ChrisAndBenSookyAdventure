using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displaystats : MonoBehaviour {

	public Text stattodisplay;
	private string ammount;
	public bool health;
	public bool gold;
	public bool Jumps;
	public bool Height;
	public bool speed;

	// Use this for initialization
	void Update () {
		if(gold == true){
			ammount =  UpgradeManager.singleton.Gold.ToString();
			stattodisplay.text = "Gold: " + ammount;
		}
		if(health == true){
			ammount = UpgradeManager.singleton.MaxPlayerHealth.ToString();
			stattodisplay.text = "Health: " + ammount;
		}
		if(Jumps == true){
			ammount = UpgradeManager.singleton.MaxNumberOfAirJumps.ToString();
			stattodisplay.text = "Jumps: " + ammount;
		}
		if(Height == true){
			ammount = UpgradeManager.singleton.jumpPower.ToString();
			stattodisplay.text = "Height: " + ammount;
		}
		if(speed == true){
			ammount = UpgradeManager.singleton.speed.ToString();
			stattodisplay.text = "Speed: " + ammount;
		}
	}

	
	
}
