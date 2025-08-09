using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoorManager : MonoBehaviour
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
                playerManager.ShowPlayerMessage("Opened Door With Key " + key_id, 2);
                Destroy(transform.parent.gameObject);
            } else {
                Debug.Log("Player does not have the key with ID: " + key_id);
                playerManager.ShowPlayerMessage("You need key " + key_id + " to open this door.", 2);
                return;
            }

        }
    }
}
