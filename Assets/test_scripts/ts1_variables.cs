using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ts1_variables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        double a = 137;
        double b = 42.141592;

        Debug.Log($"the sum is: {a + b}");
        Debug.Log($"the difference is: {a - b}");
        Debug.Log($"the product is: {a * b}");
        Debug.Log($"the division is: {a / b}");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
