using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDemonAnimation : MonoBehaviour
{
    private float gravityAcceleration = 9.81f;
    private float animationConstant = 0.02f;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private CharacterController characterController;

    // Update is called once per frame
    void Update()
    {
        AttachCharacterToGround(gravityAcceleration);
        ResetToIdleAnim();
        CheckUserInput();
    }

    private void CheckUserInput()
    {
        if (Input.GetKey(KeyCode.I))
        {
            animator.SetFloat("vertical", 1f);
        }
        else if (Input.GetKey(KeyCode.M))
        {   
            animator.SetFloat("vertical", -1f);
        }
        
        if (Input.GetKey(KeyCode.L))
        {
            animator.SetFloat("horizontal", 1f);
        }
        else if (Input.GetKey(KeyCode.J))
        {
            animator.SetFloat("horizontal", -1f);
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
}
