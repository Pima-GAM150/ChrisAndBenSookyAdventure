using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeScript : MonoBehaviour {
	
	private int HealthCost = 5;
	private int SpeedCost = 5;
	private int JumpHeightCost = 10;
	private int JumpCost = 20;
	public Text ListedCostText;
	private string CostString;
	public bool Jumps;
	public bool Height;
	public bool Speed;
	public bool Health;

	void Update(){
		if(Height == true){
			CostString = JumpHeightCost.ToString();
			ListedCostText.text = CostString;
		}
		if(Jumps == true){
			CostString = JumpCost.ToString();
			ListedCostText.text = CostString;
		}
		if(Speed == true){
			CostString = SpeedCost.ToString();
			ListedCostText.text = CostString;
		}
		if(Health == true){
			CostString = HealthCost.ToString();
			ListedCostText.text = CostString;
		}
	}


	public void UpgradeHealth(){
		if(HealthCost <= UpgradeManager.singleton.Gold){
			UpgradeManager.singleton.MaxPlayerHealth++;
			UpgradeManager.singleton.Gold -= HealthCost;
			HealthCost += HealthCost;
			ListedCostText.text = CostString;
		}

	}
	public void UpgradeSpeed(){
		if(SpeedCost <= UpgradeManager.singleton.Gold){
			UpgradeManager.singleton.speed++;
			UpgradeManager.singleton.Gold -= SpeedCost;
			SpeedCost += SpeedCost;
			ListedCostText.text = CostString;
		}

	}
	public void UpgradeJumpHeight(){
		if(JumpHeightCost <= UpgradeManager.singleton.Gold){
			UpgradeManager.singleton.jumpPower++;
			UpgradeManager.singleton.Gold -= JumpHeightCost;
			JumpHeightCost += JumpHeightCost;
			ListedCostText.text = CostString;
		}

	}
	public void UpgradeJumpNumber(){
		if(JumpCost <= UpgradeManager.singleton.Gold){
			UpgradeManager.singleton.MaxNumberOfAirJumps++;
			UpgradeManager.singleton.Gold -= JumpCost;
			JumpCost += JumpCost;
			ListedCostText.text = CostString;
		}

	}


}
