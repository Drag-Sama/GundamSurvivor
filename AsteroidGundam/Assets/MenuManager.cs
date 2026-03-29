using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void StartLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
