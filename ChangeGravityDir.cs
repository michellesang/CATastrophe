using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityDir : MonoBehaviour
{
    private ConstantForce cForce;
    private Vector3 forceDirection;

    // Start is called before the first frame update
    void Start()
    {
        cForce = GetComponent<ConstantForce>();
        forceDirection = new Vector3(0, -10, 0);
        cForce.force = forceDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            forceDirection = forceDirection * -1;
            cForce.force = forceDirection;
        }
    }
}
