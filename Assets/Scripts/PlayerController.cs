using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header("General")]
    [Tooltip("In m/s")][SerializeField] float controlSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 9f;
    [Tooltip("In m")] [SerializeField] float yRange = 8f;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-Throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float yThrow, xThrow;
    bool isDead = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isDead)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    // Handles translation of ship
    private void ProcessTranslation()
    {
        float xOffset;
        float yOffset;

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        xOffset = controlSpeed * xThrow * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float trueXPos = Mathf.Clamp(newXPos, -xRange, xRange); // Keeps ship within screen's x-range

        
        yOffset = controlSpeed * yThrow * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        float trueYPos = Mathf.Clamp(newYPos, -yRange, yRange); // Keeps ship within screen's y-range

        transform.localPosition = new Vector3(trueXPos, trueYPos, transform.localPosition.z);
    }

    // Handles rotation of ship
    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void OnPlayerDeath()
    {
        Debug.Log("i dead");
        isDead = true;
    }

}
