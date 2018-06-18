using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour {
    [Tooltip("In m/s")][SerializeField] float xSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 5.5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3.5f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlRollFactor = -20f;

    float yThrow, xThrow;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float xOffset;
        float yOffset;

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        xOffset = xSpeed * xThrow * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float trueXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        
        yOffset = xSpeed * yThrow * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        float trueYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(trueXPos, trueYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
