using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextScene : MonoBehaviour
{
    void Update()
    {
        // Check if the "Enter" key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GoToNextScene();
        }
    }

    void GoToNextScene()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
