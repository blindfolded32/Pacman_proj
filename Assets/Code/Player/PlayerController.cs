using UnityEngine;

public class PlayerController : IPlayerController
{
    private IPlayerView _playerView;
    private readonly IPlayerModel _playerModel;

    public PlayerController(IPlayerView playerView, IPlayerModel playerModel)
    {
        _playerView = playerView;
        _playerModel = playerModel;
    }
    public void OnUpdate()
    {
        Move();
    }

    private void Move()
    {
        _playerView.MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _playerView.MoveDirection = _playerView.Transform.TransformDirection(_playerView.MoveDirection);
        Debug.Log($"Moving to {_playerView.MoveDirection}");
        _playerView.MoveDirection *= _playerModel.Speed;
        _playerView.MovementControl.Move(_playerView.MoveDirection * Time.deltaTime);
        _playerView.Transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    }
}
