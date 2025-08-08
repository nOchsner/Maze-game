using UnityEngine;

public class Key_Manager : MonoBehaviour
{
    [SerializeField] private int key_id;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager playerManager = other.GetComponent<PlayerManager>();
            if (playerManager != null)
            {
                playerManager.AddKey(key_id);
                playerManager.ShowPlayerMessage("Picked up key " + key_id, 2);
                Destroy(gameObject);
            }
        }
    }
}
