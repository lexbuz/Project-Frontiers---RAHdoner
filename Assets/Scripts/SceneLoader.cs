using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject toCredits;
    public void Update()
    {
        if (toCredits.activeInHierarchy)
        {
            LoadScene(2);
        }
    }
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
