using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeScript : MonoBehaviour {
	public string LevelToLoad;
	private int HealthCost = 5;
	private int SpeedCost = 5;
	private int JumpHeightCost = 10;
	private int JumpCost = 20;

	public void loadthis(){
		SceneManager.LoadScene(LevelToLoad);
	}

	public void UpgradeHealth(){
		if(HealthCost <= UpgradeManager.singleton.Gold){
			UpgradeManager.singleton.MaxPlayerHealth++;
			UpgradeManager.singleton.Gold -= HealthCost;
			HealthCost += HealthCost;
		}

	}
	public void UpgradeSpeed(){
		if(SpeedCost <= UpgradeManager.singleton.Gold){
			UpgradeManager.singleton.speed++;
			UpgradeManager.singleton.Gold -= SpeedCost;
			SpeedCost += SpeedCost;
		}

	}
	public void UpgradeJumpHeight(){
		if(JumpHeightCost <= UpgradeManager.singleton.Gold){
			UpgradeManager.singleton.jumpPower++;
			UpgradeManager.singleton.Gold -= JumpHeightCost;
			JumpHeightCost += JumpHeightCost;
		}

	}
	public void UpgradeJumpNumber(){
		if(JumpCost <= UpgradeManager.singleton.Gold){
			UpgradeManager.singleton.MaxNumberOfAirJumps++;
			UpgradeManager.singleton.Gold -= JumpCost;
			JumpCost += JumpCost;
		}

	}


}
