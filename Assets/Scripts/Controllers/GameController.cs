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
    void Awake()
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
    private List<Spawner> enemySpawners = new List<Spawner>();
    private List<Spawner> coinSpawners = new List<Spawner>();
    private PlayerData playerData;
    
    public PlayerData PlayerData => playerData;
    public List<Spawner> EnemySpawners => enemySpawners;
    public List<Spawner> CoinSpawners => coinSpawners;
    public void RespawnPlayer()
    {
        if (!playerIsAlive && playerContainer)
        {
            playerObject = Instantiate(playerPrefab, playerContainer);
            playerIsAlive = true;
            playerData = playerObject.GetComponent<PlayerData>();
            UserInterfaceController.instance.UpdateHealth(playerData.PlayerHealth);
        }
    }

    public void RespawnEnemies()
    {
        foreach (var pos in enemySpawners)
        {
            pos.Spawn();
        }
    }
    public void RespawnCoins()
    {
        foreach (var pos in coinSpawners)
        {
            pos.Spawn();
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
            UserInterfaceController.instance.UpdateHealth(0);
        }
    }
    
    public void DealDamageToPlayer(int damage)
    {
        PlayerData.PlayerHealth -= damage;
        UserInterfaceController.instance.UpdateHealth(playerData.PlayerHealth);
    }
    
    public void RestartGame()
    {
        RespawnPlayer();
        RespawnEnemies();
        RespawnCoins();
    }
}
