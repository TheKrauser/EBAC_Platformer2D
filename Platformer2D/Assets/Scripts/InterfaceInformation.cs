using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceInformation : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text blueCoinText;

    public static InterfaceInformation Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateInterface();
    }

    public void UpdateInterface()
    {
        coinText.text = "x " + ItemManager.Instance.GetCoins();
        blueCoinText.text = "x " + ItemManager.Instance.GetBlueCoins();
    }
}
