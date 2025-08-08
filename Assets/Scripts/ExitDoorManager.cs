using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorManager : MonoBehaviour
{
    [SerializeField] private int key_id;
    private PlayerManager playerManager;
    
    private void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManager not found in the scene.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (playerManager == null)
        {
            Debug.Log("Issue, no player manager found.");
            return;
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is trying to exit the level.");

            if (playerManager.HasKey(key_id) || key_id == -1)
            {
                Debug.Log("Player has the key with ID: " + key_id);
                SceneManager.LoadScene("Win_Scene");
            } else {
                Debug.Log("Player does not have the key with ID: " + key_id);
                playerManager.ShowPlayerMessage("You need key " + key_id + " to exit.", 2);
                return;
            }

        }
    }
}
