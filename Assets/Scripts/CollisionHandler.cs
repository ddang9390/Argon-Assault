using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        gameObject.SendMessage("OnPlayerDeath");
        explosion.SetActive(true);
        Invoke("restartLevel", levelLoadDelay);
    }

    private void restartLevel() // string referenced
    {
        SceneManager.LoadScene(1);
    }
}
