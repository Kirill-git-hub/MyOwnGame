using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterfaceController : MonoBehaviour
{
    #region Singleton Creation

    public static UserInterfaceController instance = null; // Экземпляр объекта

    void Start()
    {
        // Теперь, проверяем существование экземпляра
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this;  // Задаем ссылку на экземпляр объекта
        }
        else
        {  // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }

        // Теперь нам нужно указать, чтобы объект не уничтожался
        // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);
        
    }

    #endregion
    
    public GameObject deathPanel;
    public Button restartButton;
    
    [SerializeField] private List<GameObject> heartObjects;
    [SerializeField] private GameObject heartTemplate;
    [SerializeField] private RectTransform healthConteiner;
    
    public void ShowDeathMessage()
    {
        deathPanel.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        GameController.instance.RespawnPlayer();
    }

    public void UpdateHealth(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            foreach (var item in heartObjects)
            {
                Destroy(item);
            }
            
            heartObjects.Clear();
        }
        
        for (int i = 0; i < currentHealth; i++)
        {
            if (heartObjects.Count > currentHealth)
            {
                GameObject item = heartObjects[0];
                heartObjects.Remove(item);
                Destroy(item);
            }

            if (heartObjects.Count < currentHealth)
            {
                GameObject item = Instantiate(heartTemplate, healthConteiner);
                item.SetActive(true);
                heartObjects.Add(item);
            }
        }
    }
}
