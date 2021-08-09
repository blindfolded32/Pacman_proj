using UnityEngine;


public class PlayerControl : MonoBehaviour, IDisposable
{
  
   
    [SerializeField]public float MoveSpeed = 2.0f;
    [SerializeField]private float speedOriginal;
    private bool isPlayerInvulnerable = false;
    //
    private CharacterController _MovementControl;
    private Vector3 _MoveDirection = Vector3.zero;
    public float RotateSpeed = 1.0f;
    //
    private float _pillCount;
    [SerializeField] private float _scoreMultiplier = 1.0f;
    private float _savedScore;
    [SerializeField] private float _score = 0.0f;
    private float _pillScore = 100.0f;
    void Start()
    {
        speedOriginal = MoveSpeed;
        _MovementControl = GetComponent<CharacterController>();
        //
        _pillCount = GameObject.FindGameObjectsWithTag("Pill").Length;
        _savedScore = _scoreMultiplier;
    }
    public void SetSpeedBoostOn(float speedMultiplier) => MoveSpeed *= speedMultiplier;
    public void SetSpeedBoostOff() => MoveSpeed = speedOriginal;
    public void SetScoreBoostOn(float scoreMultiplier) => _scoreMultiplier *= scoreMultiplier;
    public void SetScoreBoostOff() => _scoreMultiplier = _savedScore;

    public void SetInvulnerability(bool isInvulnerabilityOn)
    {
        isPlayerInvulnerable = isInvulnerabilityOn;
    }

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
        if (_pillCount == 0) Debug.Log("Victory");
    }
    public void Dispose(GameObject obj) => Destroy(obj);
    
}
