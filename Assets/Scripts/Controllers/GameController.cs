using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    #region Singleton creation

    public static GameController instance = null; // Экземпляр объекта

    // Метод, выполняемый при старте игры
    void Start()
    {
        // Теперь, проверяем существование экземпляра
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        { // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }

        // Теперь нам нужно указать, чтобы объект не уничтожался
        // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);

        
    }

    #endregion

    public GameObject playerPrefab = null;
    public Transform playerContainer = null;
 

    [HideInInspector]
    public GameObject playerObject = null;
    private bool playerIsAlive = false;

    public void RespawnPlayer()
    {
        if (!playerIsAlive && playerContainer)
        {
            playerObject = Instantiate(playerPrefab, playerContainer);
            playerIsAlive = true;
        }
    }

    public void KillPlayer(float killAfter = 0f)
    {
        if (playerIsAlive && playerObject)
        {
            Destroy(playerObject, killAfter);
            playerObject = null;
            playerIsAlive = false;
            UserInterfaceController.instance.ShowDeathMessage();
        }
    }
    public void DealDamageToPlayer(int damage)
    {
        playerObject.GetComponent<PlayerData>().PlayerHealth -= damage;
        UserInterfaceController.instance.ShowHealth(playerObject.GetComponent<PlayerData>().PlayerHealth);
    }
}
