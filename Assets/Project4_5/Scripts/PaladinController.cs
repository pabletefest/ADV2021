using UnityEngine;

namespace Project4_5.Scripts
{
    public class PaladinController : MonoBehaviour
    {
        private float gravityAcceleration = 9.81f;
        private float animationConstant = 0.02f;
        private float amountOfDmg = 40f;
        private float life = 500f;
    
        [SerializeField]
        private Animator animator;
    
        [SerializeField]
        private CharacterController characterController;
    
        // Update is called once per frame
        void Update()
        {
            AttachCharacterToGround(gravityAcceleration);
            //ResetToIdleAnim(); //No need for this after adjusting blend tree values over time in Update()
            CheckUserInput();
        }
    
        private void CheckUserInput()
        {
            VerticalMovement();
            HorizontalMovement();

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
    
        private void ResetToIdleAnim()
        {
            animator.SetFloat("horizontal", 0);
            animator.SetFloat("vertical", 0);
        }
    
        private void AttachCharacterToGround(float gravityAcceleration)
        {
            characterController.Move(Vector3.down * gravityAcceleration * Time.deltaTime);
        }

        private void Attack()
        {
            float randomAttack = Random.Range(0, 1f);
            
            animator.SetFloat("attack", randomAttack);
        }

        private void VerticalMovement()
        {
            float verticalMovement = animator.GetFloat("vertical");
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.I))
            {
                if (verticalMovement < 1f)
                {
                    //animator.SetFloat("vertical", 1f);
                    animator.SetFloat("vertical", verticalMovement + animationConstant);
                    
                    verticalMovement = animator.GetFloat("vertical");
                    
                    if (verticalMovement > 1f)
                        animator.SetFloat("vertical", 1f);
                }
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.K))
            {
                if (verticalMovement > -1f)
                {
                    //animator.SetFloat("vertical", -1f);
                    animator.SetFloat("vertical", verticalMovement - animationConstant);
                    
                    verticalMovement = animator.GetFloat("vertical");
                    
                    if (verticalMovement < -1f)
                        animator.SetFloat("vertical", -1f);
                }
            }
            else
            {
                if (verticalMovement > 0)
                {
                    animator.SetFloat("vertical", verticalMovement - animationConstant);
                    
                    verticalMovement = animator.GetFloat("vertical");
                    
                    if (verticalMovement < 0)
                        animator.SetFloat("vertical", 0);
                }
                else if (verticalMovement < 0)
                {
                    animator.SetFloat("vertical", verticalMovement + animationConstant);
                    
                    verticalMovement = animator.GetFloat("vertical");
                    
                    if (verticalMovement > 0)
                        animator.SetFloat("vertical", 0);
                }
            }
        }

        private void HorizontalMovement()
        {
            float horizontalMovement = animator.GetFloat("horizontal");
            
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.L))
            {
                if (horizontalMovement < 1f)
                {
                    animator.SetFloat("horizontal", horizontalMovement + animationConstant);
                    //animator.SetFloat("horizontal", 1f); 
                    
                    horizontalMovement = animator.GetFloat("horizontal");
                    
                    if (horizontalMovement > 1f)
                        animator.SetFloat("horizontal", 1f);
                }
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.J))
            {
                if (horizontalMovement > -1f)
                {
                    animator.SetFloat("horizontal", horizontalMovement - animationConstant);
                    //animator.SetFloat("horizontal", -1f);
                    
                    horizontalMovement = animator.GetFloat("horizontal");
                    
                    if (horizontalMovement < -1f)
                        animator.SetFloat("horizontal", -1f);
                }
            }
            else
            {
                if (horizontalMovement > 0)
                {
                    animator.SetFloat("horizontal", horizontalMovement - animationConstant);
                    
                    horizontalMovement = animator.GetFloat("horizontal");
                    
                    if (horizontalMovement < 0)
                        animator.SetFloat("horizontal", 0);
                }
                else if (horizontalMovement < 0)
                {
                    animator.SetFloat("horizontal", horizontalMovement + animationConstant);
                    
                    horizontalMovement = animator.GetFloat("horizontal");
                    
                    if (horizontalMovement > 0)
                        animator.SetFloat("horizontal", 0);
                }
            }
        }
    }
}
