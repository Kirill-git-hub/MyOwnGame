using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeMenuController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private string sceneName;

    private AsyncOperation loadingSceneProgress;


    private void Start()
    {
        startButton.onClick.AddListener( () => StartFirstLevel(/*method params can be here*/) );
    }

    private void Update()
    {
        if(loadingSceneProgress != null)
        {
            if (loadingSceneProgress.isDone)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void StartFirstLevel()
    {
        loadingSceneProgress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        startButton.onClick.RemoveAllListeners();
    }

    
}
