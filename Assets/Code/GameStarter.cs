using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField] private Canvas _victoryUI;
    private IPlayerController _playerController;
    private ICollectableController _collectableController;
    private ICameraController _cameraController;
    private IBonusController _bonusController;
  

    private void Start()
    {
       _playerController = new PlayerController(FindObjectOfType<PlayerView>(), new PlayerModel(_speed));
       _cameraController = new CameraController(FindObjectOfType<CameraView>(), new CameraModel());
       _collectableController = new CollectableController(new CollectableModel());
        _bonusController = new BonusController(new BonusModel());
    }
   
    private void Update()
    {
        _playerController.OnUpdate();
       // _collectableController.OnCollect();
       // _cameraController.OnInit();
      //  _bonusController.OnInit();
        if (_collectableController.OnCollect()) _victoryUI.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainScene");
      
    }
}
