using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGate : MonoBehaviour
{
    public int work = 0;
    public NotGate notGate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(work==1)
        {
            notGate.active = 1;
        }
    }
}
