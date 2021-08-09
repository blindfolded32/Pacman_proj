using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour, IDisposable
{
  
   
    [SerializeField]public float MoveSpeed = 2.0f;
    [SerializeField]private float speedOriginal;
    private bool isPlayerInvulnerable;
    public float _pill_count;

    //
    private CharacterController _MovementControl;
    private Vector3 _MoveDirection = Vector3.zero;
    public float RotateSpeed = 1.0f;
    private float score = 0;
    [SerializeField] public float PillScore;


    void Start()
    {
        speedOriginal = MoveSpeed;
        _MovementControl = GetComponent<CharacterController>();
        _pill_count = GameObject.FindGameObjectsWithTag("Pill").Length;
    }
    public void SetSpeedBoostOn(float speedMultiplier)
    {
        Debug.Log("Speed up");
        speedOriginal = MoveSpeed;
        MoveSpeed *= speedMultiplier;
    }

    public void SetSpeedBoostOff()
    {
        Debug.Log("Stop it");
        MoveSpeed = speedOriginal;
    }

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
        //Debug.Log($"Trig {other.tag}");
        if (other.CompareTag("Pill"))
        {
            Dispose(other.gameObject);
            _pill_count--;
            score += (PillScore );
            // Debug.Log(_pill_count);

        }
        if (_pill_count == 0) Debug.Log("Victory");
    }
    public void Dispose(GameObject obj)
    {
        //Debug.Log($"Kill {obj.name}");
        Destroy(obj);
    }

}
