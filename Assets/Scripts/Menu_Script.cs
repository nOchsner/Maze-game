using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{

    public void PlayGame_L1()
    {
        print("Loading Level 1");
        SceneManager.LoadScene("Level_1");
    }
    public void PlayGame_L2()
    {
        print("Loading Level 2");
        SceneManager.LoadScene("Level_2");
    }
}
