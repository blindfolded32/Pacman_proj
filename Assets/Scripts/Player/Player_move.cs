using System;
using UnityEngine;

namespace Scripts.Player
{
    public class Player_move : MonoBehaviour, IDisposable
    {

        private int _pill_count;
        private Bonus_types _bonuses;
        private CharacterController _MovementControl;
        [SerializeField]private Player_affix _affix;
        private Vector3 _MoveDirection = Vector3.zero;
        public float MoveSpeed = 2.0f;
        public float RotateSpeed = 1.0f;
        private float score = 0;
        [SerializeField] public float PillScore;
        private void Start()
        {
            _bonuses = new Bonus_types();
            _affix = new Player_affix();
            _MovementControl = GetComponent<CharacterController>();
            _pill_count = GameObject.FindGameObjectsWithTag("Pill").Length;
           _bonuses.Fill_bonus();
        }
        void Update()
        {
            Movement();
        }

        private void Movement()
        {
                _MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                _MoveDirection = transform.TransformDirection(_MoveDirection);
            _MoveDirection *= (MoveSpeed * _affix._affix_move);

            _MovementControl.Move(_MoveDirection * Time.deltaTime);
            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        }
     /*   private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collide");
            if (collision.collider.CompareTag("Pill"))
            {
                Dispose(collision.gameObject);
                _pill_count--;
                score += (PillScore * _affix._affix_score);
                Debug.Log(_pill_count);

            }
            if (_pill_count == 0) Debug.Log("Victory");
            
        }*/


        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log($"Trig {other.tag}");
            if (other.CompareTag("Pill"))
            {
                Dispose(other.gameObject);
                _pill_count--;
                score += (PillScore * _affix._affix_score);
                Debug.Log(_pill_count);

            }
            if (_pill_count == 0) Debug.Log("Victory");
        }
        public void Dispose(GameObject obj)
        {
            //Debug.Log($"Kill {obj.name}");
            Destroy(obj);
        }
    }
}