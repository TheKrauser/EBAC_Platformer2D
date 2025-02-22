using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public SOInt coins;
    public SOInt blueCoins;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        blueCoins.value = 0;
        InterfaceInformation.Instance.UpdateInterface();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

    public void AddBlueCoins(int amount = 1)
    {
        blueCoins.value += amount;
    }

    public int GetCoins()
    {
        return coins.value;
    }

    public int GetBlueCoins()
    {
        return blueCoins.value;
    }
}
