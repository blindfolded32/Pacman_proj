using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField] private Canvas _victoryUI;
    [SerializeField] private RenderTexture _texture;
    [SerializeField] private Camera _miniMapCamera;
    private IPlayerController _playerController;
    private ICollectableController _collectableController;
    private IEnemyController _enemyController;
    private ICameraController _cameraController;
    private IBonusController _bonusController;
    private IMiniMapController _miniMapController;
    private BonusEventTransfer _bonusEvent;
    private void Start()
    {
       _bonusController = new BonusController(new BonusModel());
       _collectableController = new CollectableController(new CollectableModel());
       _playerController = new PlayerController(FindObjectOfType<PlayerView>(), new PlayerModel(_speed), _bonusController);
       _cameraController = new CameraController(FindObjectOfType<CameraView>(), new CameraModel());
       _enemyController = new EnemyController(new EnemyModel(_speed), _bonusController);
       _bonusEvent = new BonusEventTransfer(_bonusController,_playerController,_cameraController,_enemyController);
       _miniMapController = new MiniMapController(FindObjectOfType<MiniMapView>().transform,FindObjectOfType<PlayerView>().transform,new MiniMapModel(_texture,_miniMapCamera), FindObjectOfType<MiniMapView>() );
    }
   
    private void Update()
    {
        _playerController.OnUpdate();
       
        if (_collectableController.OnCollect()) _victoryUI.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainScene");
      
    }

    private void LateUpdate()
    {
        _miniMapController.OnLateExecute();
    }
}
