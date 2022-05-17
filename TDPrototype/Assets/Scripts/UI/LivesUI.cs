using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [Header("Lives UI")]
    public TextMeshProUGUI livesText;

    //Update lives everyframe (is not optimal but for a small game prototype works)
    private void Update()
    {
        livesText.text = Stats.Lives.ToString();
    }
}
