using UnityEngine;

namespace CameraScripts
{
    public class TargetFollowScript : MonoBehaviour
    {
        [SerializeField] private Transform mainCamera;
        [SerializeField] private Transform player;
        [SerializeField] private float cameraFollowSpeed = 5f;
        private Vector3 _distanceFromPlayer;

        void Start()
        {
            _distanceFromPlayer = transform.position - player.position;
        }

        private void FixedUpdate()
        {
            MoveTheCamera();
        }

        private void MoveTheCamera()
        {
            if (player != null)
            {
                var playerPosition = player.position;
                var targetPosition = playerPosition + _distanceFromPlayer;
                mainCamera.position = Vector3.Lerp(mainCamera.position, targetPosition, cameraFollowSpeed * Time.fixedDeltaTime);
                mainCamera.LookAt(playerPosition);
            }
        }

        private Vector3 CalculateDistanceFromPlayer(Transform newTarget)
        {
            return transform.position - newTarget.position;
        }
    }
}
