using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seconds_movement_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string time_string = DateTime.Now.TimeOfDay.ToString();
        
        string[] list_time_elements = time_string.Split(":");
        int hours24 = Int32.Parse(list_time_elements[0]);
        int hours = hours24 % 12;
        int am_pm = hours24 / 12;
        int minutes = Int32.Parse(list_time_elements[1]);
        int seconds = Int32.Parse(list_time_elements[2].Split(".")[0]);

        float y_angle = 6 * seconds;
        Vector3 rotation_vector = new Vector3(0.0f, y_angle, 0.0f);

        gameObject.transform.Rotate(rotation_vector, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
