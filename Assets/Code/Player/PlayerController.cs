using System.Collections;
using UnityEngine;

public class PlayerController : IPlayerController
{
    private IPlayerView _playerView;
    private IPlayerModel _playerModel;

    private float _duration = 4.0f;
    public PlayerController(IPlayerView playerView, IPlayerModel playerModel, IBonusController bonusController)
    {
        _playerView = playerView;
        _playerModel = playerModel;
        bonusController.SpeedCollect += (x) => BoostSpeed((float)x);
    }
    public void OnUpdate()
    {
        Move();
    }

    private void BoostSpeed(float multiplier) 
    {
        float _originSpeed = _playerModel.Speed;
        _playerModel.Speed *= multiplier;
        _playerView.ChildCourutine(BonusDuration(_duration));
        
    }

    private void GodMode()
    {
        _playerModel._isPlayerInvulnerable = true;
    }

    private void Move()
    {
        _playerView.MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _playerView.MoveDirection = _playerView.Transform.TransformDirection(_playerView.MoveDirection);
        _playerView.MoveDirection *= _playerModel.Speed;
        _playerView.MovementControl.Move(_playerView.MoveDirection * Time.deltaTime);
        _playerView.Transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    }

    private IEnumerator BonusDuration(float duration)
    {
        Debug.Log(_playerModel.Speed);
        yield return new WaitForSeconds(duration);
        _playerModel.Speed = 2.0f;
    }
}
