using UnityEngine;

public class Stats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    [Header("Money & Lives Stats")]
    [SerializeField] private int startMoney = 150;
    [SerializeField] private int startLives = 20;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
