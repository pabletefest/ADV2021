using UnityEngine;
using Random = UnityEngine.Random;

namespace Project4_5.Scripts
{
    public class PaladinController : MonoBehaviour
    {
        private float gravityAcceleration = 9.81f;
        private float animationConstant = 0.02f;
        private float amountOfDmg = 40f;
        private float life = 500f;
        //private bool canHitEnemy;
        //private Collider enemyCollider;
        [SerializeField] private GameObject mutantHitPoint;
        [SerializeField] private GameObject zombie1HitPoint;
        [SerializeField] private GameObject zombie2HitPoint;
        [SerializeField] private GameObject zombie3HitPoint;

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
            
            string enemyTag = GetNearestEnemyTag();
            
            if (enemyTag != "")
                DamageEnemyByTag(enemyTag);
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
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.J))
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

        private string GetNearestEnemyTag()
        {
            if (Vector3.Distance(mutantHitPoint.transform.position, transform.position) < 1f)
            {
                Debug.Log("hit BossMutant");
                return "BossMutant";
            }
            else if (Vector3.Distance(zombie1HitPoint.transform.position, transform.position) < 1f)
            {
                Debug.Log("hit Zombie1");
                return "Zombie1";
            }
            else if (Vector3.Distance(zombie2HitPoint.transform.position, transform.position) < 1f)
            {
                Debug.Log("hit Zombie2");
                return "Zombie2";
            }
            else if (Vector3.Distance(zombie3HitPoint.transform.position, transform.position) < 1f)
            {
                Debug.Log("hit Zombie3");
                return "Zombie3";
            }

            return "";
        }

        private void DamageEnemyByTag(string tag)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag(tag);
            enemy.GetComponent<EnemyHealth>().TakeDamage(amountOfDmg);
            Debug.Log($"Enemy hit {tag}");
        }  
    }
}
