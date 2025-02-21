using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private Transform playerSpawn;

    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = playerSpawn.position;
    }
}
