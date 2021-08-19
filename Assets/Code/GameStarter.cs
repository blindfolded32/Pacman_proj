using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField]private float _speed;
    private IPlayerController _playerController;

    private void Start()
    {
       _playerController = new PlayerController(FindObjectOfType<PlayerView>(), new PlayerModel(_speed));
    }

    private void Update()
    {
        _playerController.OnUpdate();
    }
}
