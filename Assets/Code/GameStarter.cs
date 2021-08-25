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
    private IBonusController _bonusController;
    private ICameraController _cameraController;
   
  

    private void Start()
    {
       _playerController = new PlayerController(FindObjectOfType<PlayerView>(), new PlayerModel(_speed));
       _collectableController = new CollectableController(new CollectableModel());
        _bonusController = new BonusController(new BonusModel());
        _cameraController = new CameraController(FindObjectOfType<CameraView>(), new CameraModel());
        _bonusController.SpeedCollect += (x) =>_cameraController.Shake(1.0f);
    }
   
    private void Update()
    {
        _playerController.OnUpdate();
       // _collectableController.OnCollect();
        if (_collectableController.OnCollect()) _victoryUI.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainScene");
      
    }
}
