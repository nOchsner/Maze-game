using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Script : MonoBehaviour
{
    void Start()
    {
        // I need to unlock te cursor when the win scene is loaded
        Cursor.lockState = CursorLockMode.None;
        
    }
    public void Menu()
    {
        print("Loading Menu");
        SceneManager.LoadScene("Menu");
    }
}
