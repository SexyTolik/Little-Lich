using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyHealTrigger : MonoBehaviour
{
    public int Cost;
    public GameObject BuyScreen;
    public Button UseButton;
    public TextMeshProUGUI Text;
    public HeathBeh PlayerHP;

    public string HelloText, BuyGoodText, BuyBadText, AlreadyFull;

    private bool InTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !InTrigger)
        {
            UseButton.gameObject.SetActive(true);
            UseButton.onClick.AddListener(OpenDialog);
            InTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UseButton.gameObject.SetActive(false);
            UseButton.onClick.RemoveAllListeners();
            InTrigger = false;
        }
    }

    private void OpenDialog()
    {
        BuyScreen.gameObject.SetActive(true);
        Text.text = HelloText;
    }
    public void BuyHeal()
    {
        if(PlayerHP.Health != PlayerHP.MaxHealth)
        {
            if (PlayerValuesStorage.instance.TryBuy(Cost))
            {
                PlayerHP.AddHealth(PlayerHP.MaxHealth);
                Text.text = BuyGoodText;
            }
            else
            {
                Text.text = BuyBadText;
            }
        }
        else
        {
            Text.text = AlreadyFull;
        }

    }

    public void ExitDialog()
    {
        BuyScreen.gameObject.SetActive(false);
        UseButton.gameObject.SetActive(false);
        UseButton.onClick.RemoveAllListeners();
        InTrigger = false;
    }
}
