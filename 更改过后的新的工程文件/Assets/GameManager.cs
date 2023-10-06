using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    private void Awake()
    {
        Instance = this;
    }

    public void SetPlayer(GameObject _player)
    {
        player = _player;
    }
}
