using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string booleanParameter;

    private bool toggle = false;

    private void OnTriggerEnter(Collider other)
    {
        toggle = !toggle;
        animator.SetBool(booleanParameter, toggle);
    }
}
