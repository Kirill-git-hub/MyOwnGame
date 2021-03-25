using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] List<string> scenes;

    // Start is called before the first frame update
    void Start()
    {
        foreach(string sceneName in scenes)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            //TODO remove this comment lol
        }
    }

}
