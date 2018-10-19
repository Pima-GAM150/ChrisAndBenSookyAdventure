using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchandMove : MonoBehaviour {
	public string LevelToLoad;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D Touch)
    {
        if (Touch.gameObject.tag == "Player")
        {
            
           SceneManager.LoadScene(LevelToLoad);
        }
        else
        {
            
        }
}
}