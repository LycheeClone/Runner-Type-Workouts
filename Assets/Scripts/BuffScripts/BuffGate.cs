// // using System;
// // using UnityEngine;
// //
// // namespace BuffScripts
// // {
// //     public class BuffGate : MonoBehaviour
// //     {
// //         
// //         public GameObject playerPrefab; // reference to the player prefab
// //         public float cloneDistance = 1.0f; // distance between the original player and the cloned player
// //         private void OnTriggerEnter(Collider other)
// //         {
// //             if (other.gameObject.CompareTag("BuffArea"))
// //             {
// //                 // Choose a random angle around the player
// //                 float randomAngle = UnityEngine.Random.Range(0, 360);
// //                 Vector3 randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
// //
// //                 // Position the cloned player in the random direction around the original player
// //                 Vector3 clonePosition = transform.position + randomDirection * cloneDistance;
// //                 GameObject playerClone = Instantiate(playerPrefab, clonePosition, transform.rotation);
// //             } 
// //         }
// //     }
// // }
// using System;
// using UnityEngine;
//
// namespace BuffScripts
// {
//     public class BuffGate : MonoBehaviour
//     {
//         public GameObject playerPrefab; // reference to the player prefab
//         public float cloneDistance = 1.0f; // distance between the original player and the cloned player
//
//         private void OnTriggerEnter(Collider other)
//         {
//             if (other.gameObject.CompareTag("BuffArea"))
//             {
//                 // Choose a random angle around the player
//                 float randomAngle = UnityEngine.Random.Range(0, 360);
//                 Vector3 randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.forward;
//
//                 // Position the cloned player in the random direction around the original player
//                 Vector3 clonePosition = transform.position + randomDirection * cloneDistance;
//                 GameObject playerClone = Instantiate(playerPrefab, clonePosition, transform.rotation);
//                 playerClone.layer = LayerMask.NameToLayer("Clone");
//
//                 
//                 // Make the cloned player a child object of the original player
//                 playerClone.transform.parent = transform;
//             } 
//         }
//     }
// }

// using System.Collections.Generic;
// using UnityEngine;
//
// public class BuffGate : MonoBehaviour
// {
//     public GameObject playerPrefab; // reference to the player prefab
//     public float cloneDistance = 1.0f; // distance between the original player and the cloned player
//     //public int maxClones = 3; // maximum number of clones allowed
//     private List<GameObject> clones = new List<GameObject>(); // list of all clones created so far
//     private GameObject player; // reference to the player object
//
//     private void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player"); // find the player object by tag
//     }
//
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.CompareTag("BuffArea"))
//         {
//             // Place the cloned player at a fixed distance and angle from the original player
//             Vector3 clonePosition = player.transform.position + player.transform.forward * cloneDistance;
//             GameObject playerClone = Instantiate(playerPrefab, clonePosition, player.transform.rotation, player.transform);
//             playerClone.tag = "Clone"; // give the clone a unique tag
//
//             clones.Add(playerClone); // add the clone to the list of clones
//
//             // Disable collision between clones
//             int cloneLayer = LayerMask.NameToLayer("Clone");
//             Physics.IgnoreLayerCollision(cloneLayer, cloneLayer, true);
//         }
//     }
// }

using System.Collections.Generic;
using UnityEngine;

namespace BuffScripts
{
    public class BuffGate : MonoBehaviour
    {
        public GameObject playerPrefab; // reference to the player prefab
        public float cloneDistance = 1.0f; // distance between the original player and the cloned player
        private List<GameObject> clones = new List<GameObject>(); // list of all clones created so far
        private GameObject player; // reference to the player object

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player"); // find the player object by tag
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BuffArea"))
            {
                // Place the cloned player at a fixed distance and angle from the original player
                Vector3 clonePosition = player.transform.position + player.transform.right * Random.Range(-cloneDistance, cloneDistance)
                                                                  + player.transform.forward * Random.Range(-cloneDistance, cloneDistance);
                GameObject playerClone = Instantiate(playerPrefab, clonePosition, player.transform.rotation);
                playerClone.tag = "Clone"; // give the clone a unique tag

                clones.Add(playerClone); // add the clone to the list of clones

                // Disable physics for the clone
                playerClone.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}



