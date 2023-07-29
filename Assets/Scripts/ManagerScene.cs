using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScene : MonoBehaviour
{
    public Button btnPlay;

    public void Start()
    {
        btnPlay.onClick.AddListener(LoadNextScene);   
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    
}
