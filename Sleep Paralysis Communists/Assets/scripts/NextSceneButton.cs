using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextScene : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void LoadNextScene()
    {
        // Get the current active scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Load the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
