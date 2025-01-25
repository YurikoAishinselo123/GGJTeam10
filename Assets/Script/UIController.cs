using UnityEngine;
using TMPro;  
public class UIController : MonoBehaviour
{
    public TextMeshProUGUI coinText;  

    public FishController fishController;

    void Start()
    {
        fishController = FindObjectOfType<FishController>();
    }

    void Update()
    {
        if (fishController != null)
        {
            coinText.text = "Coins: " + fishController.coinCount.ToString();
        }
    }
}
