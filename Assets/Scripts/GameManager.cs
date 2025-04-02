using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopItem
{
    public Color color;            
    public int cost;               
    public bool unlocked = false; 
}

public class GameManager : MonoBehaviour
{
    public GameObject mainMenuPanel;  
    public GameObject shopPanel;       

    public Button playButton;
    public Button shopButton;
    public Button exitButton;
    public Button shopBackButton;
    public Button cancelGameButton;  

    public int coins = 100;            
    public Text coinText;             

    public ShopItem[] shopItems;      
    public GameObject[] shopButtons;   

    
    public GameObject ball;         

    public Text messageText;         
    public float messageDuration = 2f; 

    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", coins);

        Time.timeScale = 0f;
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (shopPanel != null) shopPanel.SetActive(false);
        if (cancelGameButton != null) cancelGameButton.gameObject.SetActive(false);

        if (playButton != null) playButton.onClick.AddListener(PlayGame);
        if (shopButton != null) shopButton.onClick.AddListener(OpenShop);
        if (exitButton != null) exitButton.onClick.AddListener(ExitGame);
        if (shopBackButton != null) shopBackButton.onClick.AddListener(BackToMenu);
        if (cancelGameButton != null) cancelGameButton.onClick.AddListener(CancelGame);

        UpdateCoinText();
    }

    public void PlayGame()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (cancelGameButton != null) cancelGameButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
        ShowMessage("¡A jugar!");
    }

    public void OpenShop()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (shopPanel != null) shopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToMenu()
    {
        if (shopPanel != null) shopPanel.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CancelGame()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();

        Time.timeScale = 0f;
        if (cancelGameButton != null) cancelGameButton.gameObject.SetActive(false);
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        ShowMessage("Partida cancelada.");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

    public void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }

    public void OnShopItemClicked(int index)
    {
        if (index < 0 || index >= shopItems.Length) return;

        ShopItem item = shopItems[index];
        if (!item.unlocked)
        {
            if (coins >= item.cost)
            {
                coins -= item.cost;
                item.unlocked = true;
                UpdateCoinText();
                ShowMessage("Color desbloqueado!");
                ChangeBallColor(item.color);
            }
            else
            {
                ShowMessage("No tienes suficientes monedas.");
            }
        }
        else
        {
            ChangeBallColor(item.color);
            ShowMessage("Color cambiado.");
        }
    }

    public void ChangeBallColor(Color newColor)
    {
        if (ball != null)
        {
            Renderer rend = ball.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material.color = newColor;
            }
        }
    }
   
    public void ShowMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
            CancelInvoke("ClearMessage");
            Invoke("ClearMessage", messageDuration);
        }
    }

    void ClearMessage()
    {
        if (messageText != null)
        {
            messageText.text = "";
        }
    }
}
