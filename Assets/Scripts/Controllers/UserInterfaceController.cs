using System.Collections;
using System.Collections.Generic;
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

    public TextMeshProUGUI healthText;
    public GameObject deathPanel;
    public Button restartButton;
    
    [SerializeField] private Image[] heartImage;
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;
    private PlayerData playerData;
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
        playerData = GameController.instance.playerObject.GetComponent<PlayerData>();

        for (int i = 0; i < heartImage.Length; i++)
        {
            if (i < playerData.PlayerHealth)
            {
                heartImage[i].enabled = true;
            }
            else
            {
                heartImage[i].enabled = false;
            }
        }
        healthText.SetText(currentHealth.ToString());
    }
}
