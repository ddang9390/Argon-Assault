using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    private void Awake()
    {
        //Debug.Log("Music player start");
        //Debug.Log("Music player awake: " + GetInstanceID());
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate music player dead");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
