using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _playerRb;
        [SerializeField] private float moveSpeed;
        public GameObject playerNumber;
        public Transform playerTransform;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            GetMovementInput();
        }

        private Vector3 GetMovementInput()
        {
            float x = Input.GetAxis("Vertical");
            float z = Input.GetAxis("Horizontal") * -1f;
            Vector3 movement = new Vector3(x * moveSpeed * Time.fixedDeltaTime, 0, z * moveSpeed * Time.fixedDeltaTime);
            _playerRb.MovePosition(transform.position + movement);
            return movement.normalized;
        }
    }
}