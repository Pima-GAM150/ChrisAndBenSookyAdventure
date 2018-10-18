using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenePlay : MonoBehaviour {

	public string LevelToLoad;

	public void loadthis(){
		SceneManager.LoadScene(LevelToLoad);
	}
}
