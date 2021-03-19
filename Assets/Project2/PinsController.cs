using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PinsController : MonoBehaviour
{
    [SerializeField]
    private List<Rigidbody> rbs;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActivatePhysicsPins", 9.23f);
    }
    
    private void ActivatePhysicsPins() 
    {
        rbs.Select(rb => rb.isKinematic = false).ToList();
    }
}
