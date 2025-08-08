using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{

    public void PlayGame()
    {
        print("Loading Level 1");
        SceneManager.LoadScene("Level_1");
    }
}
