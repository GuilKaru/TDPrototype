using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [Header("Money UI")]
    public TextMeshProUGUI moneyText;

    //Update Money everyframe (is not optimal but for a small game prototype works)
    private void Update()
    {
        moneyText.text = "$" + Stats.Money.ToString();
    }
}
