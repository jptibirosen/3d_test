using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ts4_functions : MonoBehaviour
{   
    //var SphereRender = TrafficSphere.GetComponent<Renderer>();


    string current_color = "";

    void SetColor(string color){
        if (color != current_color){
            Debug.Log($"The color is {color}");
            current_color = color;

            if (color == "red"){
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            if (color == "yellow"){
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            if (color == "green"){
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
            
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetColor("red");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < 3.0f){
            SetColor("red");
        }
        if (3.0f <= Time.time && Time.time < 5.0f){
            SetColor("yellow");
        }
        if (5.0f <= Time.time){
            SetColor("green");
        }

    }
}
