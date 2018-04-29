using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene(int sceneToChangeTo)
    {
        //load the scene passed as a parameter
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
