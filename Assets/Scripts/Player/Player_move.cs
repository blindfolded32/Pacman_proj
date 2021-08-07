
using UnityEngine;

namespace Scripts.Player
{
    public class Player_move : MonoBehaviour
    {

       
        private Bonus_types _bonuses;
        private CharacterController _MovementControl;
        private Vector3 _MoveDirection = Vector3.zero;
        public float MoveSpeed, RotateSpeed;

        private void Awake()
        {
            _bonuses.Fill_bonus();
        }
        private void Start()
        {
            _MovementControl = GetComponent<CharacterController>();
        }
        void Update()
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

    }
}