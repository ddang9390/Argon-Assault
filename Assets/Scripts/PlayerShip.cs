using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour {
    [Tooltip("In m/s")][SerializeField] float xSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xOffset;
        float yOffset;

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        xOffset = xSpeed * xThrow * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float trueXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        yOffset = xSpeed * yThrow * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        float trueYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(trueXPos, trueYPos, transform.localPosition.z);
	}
}
