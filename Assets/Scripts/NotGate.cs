using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : MonoBehaviour
{
    public int active = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active==0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.9194385f, 0f, 0.5019608f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.9194385f, 0f, 1f);
        }
    }
}
