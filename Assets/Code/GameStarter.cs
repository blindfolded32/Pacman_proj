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
    private IEnemyController _enemyController;
    private ICameraController _cameraController;
    private IBonusController _bonusController;

  

    private void Start()
    {
        _bonusController = new BonusController(new BonusModel());
       _playerController = new PlayerController(FindObjectOfType<PlayerView>(), new PlayerModel(_speed), _bonusController);
       _collectableController = new CollectableController(new CollectableModel());
        _enemyController = new EnemyController(new EnemyModel(_speed), _bonusController);
       _cameraController = new CameraController(FindObjectOfType<CameraView>(), new CameraModel(), _bonusController);

    }
   
    private void Update()
    {
        _playerController.OnUpdate();

        if (_collectableController.OnCollect()) _victoryUI.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainScene");
      
    }
}
