using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int sceneBuildIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
