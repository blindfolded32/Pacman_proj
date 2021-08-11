using System.Collections;
using UnityEngine;
using static UnityEngine.Debug;

namespace Scripts.Game
{

public class PlayerControl : MonoBehaviour, IDisposable
{
  
   
    public float MoveSpeed = 2.0f;
    private float _speedOriginal;
    private bool _isPlayerInvulnerable = false;
    //
    private CharacterController _MovementControl;
    private Vector3 _MoveDirection = Vector3.zero;
    public float RotateSpeed = 1.0f;
    //
    private float _pillCount;
    private float _scoreMultiplier = 1.0f;
    private float _savedScore;
    private float _score = 0.0f;
    private float _pillScore = 100.0f;
    //
    public float shakeDuration = .8f;
    private Quaternion _originalRotation;
        //
        protected Bonuses[] _bonuses;
    void Start()
    {
        _speedOriginal = MoveSpeed;
        _MovementControl = GetComponent<CharacterController>();
        //
        _pillCount = GameObject.FindGameObjectsWithTag("Pill").Length;
        _savedScore = _scoreMultiplier;
        //
        _originalRotation = Camera.main.transform.localRotation;
        OnBonusCollect();
    }

        private void OnBonusCollect()
        {
            _bonuses = FindObjectsOfType<Bonuses>();
            foreach (var bonus in _bonuses)
            bonus.OnCollected += (type,mod) => { Log("hear touch"); ChooseBonus(type,mod);} ;
        }
        private void ChooseBonus(string type, object mod)
        {
           Log($"boosting {type} to {mod}");
            switch (type)
            {
                case "MoveSpeed":
                    SetSpeedBoostOn((float)mod);
                    StartCoroutine(BonusDuration(10));
                   
                    break;
                case "Score":
                    SetScoreBoostOn((float)mod);
                    StartCoroutine(BonusDuration(10));
                   
                    break;
                case "GodMode":
                    SetGodModeOn();
                    StartCoroutine(BonusDuration(10));
                  
                    break;
            }
        }
    public void SetSpeedBoostOn(float speedMultiplier)
    {
        MoveSpeed *= speedMultiplier;
            Log($"boosting {MoveSpeed} to {speedMultiplier}");
            Shake();
    }
    public void SetSpeedBoostOff() => MoveSpeed = _speedOriginal;
    public void SetScoreBoostOn(float scoreMultiplier) => _scoreMultiplier *= scoreMultiplier;
    public void SetScoreBoostOff() => _scoreMultiplier = _savedScore;
    public void SetGodModeOn()=> _isPlayerInvulnerable = true;
    public void SetGodModeOff() => _isPlayerInvulnerable = false;
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        _MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _MoveDirection = transform.TransformDirection(_MoveDirection);
        _MoveDirection *= MoveSpeed;       
        _MovementControl.Move(_MoveDirection * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Pill"))
        {
            _pillCount--;
            _score += (_pillScore * _scoreMultiplier);
            Dispose(other.gameObject);
        }
        if (_pillCount == 0) Log("Victory");
    }
    IEnumerator BonusDuration(float duration)
        {
            yield return new WaitForSeconds(duration);
        }
    #region Camera shake Вынести!!!!
    public void Shake()
    {

        Log($"Shake it {_originalRotation}");
        StartCoroutine(ShakigCamera());
        Camera.main.transform.localRotation = _originalRotation;
        Log($"AfterShake it {_originalRotation}");
    }

    IEnumerator ShakigCamera()
    {

        float timeLeft = Time.time;

        while ((timeLeft + shakeDuration) > Time.time)
        {
            Camera.main.transform.localRotation = new Quaternion(_originalRotation.x, Random.Range(-0.02f, 0.02f), Random.Range(-0.02f, 0.02f), 1.0f);
            yield return new WaitForSeconds(0.025f);

        }
       
    }
    #endregion
    public void Dispose(GameObject obj) => Destroy(obj);
    
}
}
