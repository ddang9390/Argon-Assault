﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int scorePerKill = 1000;
    [SerializeField] int health = 3;

    ScoreBoard scoreBoard;

    // Use this for initialization
    void Start () {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;

        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        health--;
        if (health <= 0)
        {
            scoreBoard.gainPoints(scorePerKill);
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            Destroy(gameObject);
        }
    }

}
