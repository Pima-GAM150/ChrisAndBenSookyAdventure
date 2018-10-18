using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    public static UpgradeManager singleton;
    public int MaxNumberOfAirJumps;
    public float speed;
    public float PlayerDamage;
    public float jumpPower;
    public float MaxPlayerHealth;
    public int Gold; 
    

	// Use this for initialization
	void Start () {
		if(singleton != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
