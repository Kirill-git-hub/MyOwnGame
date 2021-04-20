using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour
{
    #region Singleton Creation

    public static UserInterfaceController instance = null; // Экземпляр объекта

    void Awake()
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
    
    private List<GameObject> heartObjects = new List<GameObject>();
    [SerializeField] private GameObject heartTemplate;
    [SerializeField] private RectTransform healthContainer;
    [SerializeField] private TextMeshProUGUI coinsText;

    public void TriggerDeathPanel()
    {
        deathPanel.gameObject.SetActive(!deathPanel.activeSelf);
    }

    public void TriggerRestart()
    {
        GameController.instance.RestartGame();
        coinsText.text = "x " + 0;
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
                GameObject item = Instantiate(heartTemplate, healthContainer);
                item.SetActive(true);
                heartObjects.Add(item);
            }
        }
    }

    public void ShowCoins()
    {
        coinsText.text = "x " + GameController.instance.PlayerData.PlayerCoins;
    }
}
