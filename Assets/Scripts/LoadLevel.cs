using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("loadGame", 10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void loadGame()
    {
        SceneManager.LoadScene(1);
    }
}
