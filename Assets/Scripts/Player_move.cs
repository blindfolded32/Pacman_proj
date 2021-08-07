
using UnityEngine;

namespace Scripts.Player
{
    public class Player_move : MonoBehaviour
    {

        
        private CharacterController _MovementControl;
        private Vector3 _MoveDirection = Vector3.zero;
        public float MoveSpeed, RotateSpeed;
        private Animator _animator;

        /*   private CharacterController controller;
           private Vector3 playerVelocity;
           private bool groundedPlayer;
           private float playerSpeed = 2.0f;
           private float jumpHeight = 1.0f;
           private float gravityValue = -9.81f;

           private void Start()
           {
               controller = gameObject.GetComponent<CharacterController>();
           }

           void Update()
           {


               Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
               controller.Move(move * Time.deltaTime * playerSpeed);

               if (move != Vector3.zero)
               {
                   gameObject.transform.forward = move;
               }
               controller.Move(playerVelocity * Time.deltaTime);
           }*/
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