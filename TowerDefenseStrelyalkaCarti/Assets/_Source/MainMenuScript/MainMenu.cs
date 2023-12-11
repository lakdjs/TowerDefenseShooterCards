using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   
    public void StartGame(int SceneID)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneID);

    }

    
    public void ExitGame()
    {
        Debug.Log("Game closed");
        Application.Quit();
    }
}
