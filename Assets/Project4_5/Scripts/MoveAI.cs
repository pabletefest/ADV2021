using UnityEngine;
using UnityEngine.AI;

namespace Project4_5.Scripts
{
    public class MoveAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent playerAgent;
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Camera mainCamera;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    playerAgent.destination = hitInfo.point;
                }
            }

            /*if (playerAgent.isOnOffMeshLink)
        {
            playerAnimator.SetTrigger("Jump");
        }*/
        
            playerAnimator.SetFloat("horizontal", transform.InverseTransformDirection(playerAgent.velocity).x);
            playerAnimator.SetFloat("vertical", transform.InverseTransformDirection(playerAgent.velocity).z);
        }
    }
}
