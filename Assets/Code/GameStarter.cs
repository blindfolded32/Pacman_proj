using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    [SerializeField]private float _speed;
    private IPlayerController _playerController;
    private ICollectableController _collectableController;
   
  

    private void Start()
    {
       _playerController = new PlayerController(FindObjectOfType<PlayerView>(), new PlayerModel(_speed));
       _collectableController = new CollectableController(new CollectableModel());
      
    }
   
    private void Update()
    {
        _playerController.OnUpdate();
        _collectableController.OnCollect();
        if (_collectableController.OnCollect()) Debug.Log("win");
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainScene");
      
    }
}
