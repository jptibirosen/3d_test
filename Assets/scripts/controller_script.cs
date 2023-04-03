using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*we will implement the clock by calling a "tick" function every second which rotates each arm by the apropriate amount of degrees*/

public class controller_script : MonoBehaviour
{   

    [SerializeField] GameObject hour_pivot;
    [SerializeField] GameObject minute_pivot;
    [SerializeField] GameObject second_pivot;
    [SerializeField] TextMeshPro am_pm_display;
    [SerializeField] bool warp_speed = false;   //use this to speed up time

    

    

    float elapsed = 0.0f;   //used by "tick_2"; pay no attention to it

    List<int> Get_time(){    
        /* we retrieve the current time and break it down into hours(12), minutes, seconds and time of day AM/PM (can take 0 or 1)
        and return it as a list of integers*/
        string time_string = DateTime.Now.TimeOfDay.ToString();

        string[] list_time_elements = time_string.Split(":");
        int hours24 = Int32.Parse(list_time_elements[0]);
        int hours = hours24 % 12;
        int am_pm = hours24 / 12;
        int minutes = Int32.Parse(list_time_elements[1]);
        int seconds = Int32.Parse(list_time_elements[2].Split(".")[0]);

        Debug.Log(time_string); //we check that everithing went fine
        Debug.Log($"hours {hours}, minutes {minutes}, seconds {seconds}");
        
        return new List<int>{hours, minutes, seconds, am_pm};
    }


    void Set_am_pm(int time_of_day){
        /*takes an integer 0 or 1 as argument and sets the time of day display to "AM" or "PM"*/
        if (time_of_day == 0) {
            //am_pm_display.GetComponent<TextMeshPro>().text = "AM";
            am_pm_display.text = "AM";
        }
        else{
            am_pm_display.text = "PM";
        }
    }


    void Set_time(List<int> time_list){    
        /*this function takes a list of integers as an argument containing hours, minutes, seconds and time of day (0 or 1)
        and sets the arms of the clock to the corresponding positions as well as the time of day display*/

        int hours = time_list[0];
        int minutes = time_list[1];
        int seconds = time_list[2];
        int am_pm = time_list[3];
        
        //we set the hour arm to the current time position
        float hour_y_angle = 30 * hours  + (minutes * 30)/59;    /*the second term makes sure the hour hand moves 30 degrees for every 
                                                                59 minutes. OMMITTING A SECONDS COMPONENT MEANS OUR HOUR HAND CAN 
                                                                LAG BEHIND BY AS MUCH AS A MINUTE!*/
        Vector3 hour_rotation_vector = new Vector3(0.0f, hour_y_angle, 0.0f);

        hour_pivot.transform.Rotate(hour_rotation_vector, Space.Self);

        //we set the minute arm to the current time position
        float minute_y_angle = 6 * minutes + (seconds * 6)/59;    /*the second term makes sure the minute hand moves 
                                                                    6 degrees for every 59 seconds*/
        Vector3 minute_rotation_vector = new Vector3(0.0f, minute_y_angle, 0.0f);

        minute_pivot.transform.Rotate(minute_rotation_vector, Space.Self);

        //we set the second arm to the current time position
        float second_y_angle = 6 * seconds;
        Vector3 second_rotation_vector = new Vector3(0.0f, second_y_angle, 0.0f);

        second_pivot.transform.Rotate(second_rotation_vector, Space.Self);

        //finally we set the time of day display
        Set_am_pm(am_pm);
        
    }

    void Tick(){
        /*this function moves the three arms of the clock by the amount they travel in one second*/

        int warp_factor = 1;
        if (warp_speed){
            warp_factor = 500;
        }
       

        float second_angle_step = 360 / 60;
        double minute_angle_step = 360 / 3600.0;
        double hour_angle_step = 360 / (float)(12 * 3600);

        Vector3 second_rotation_step = new Vector3(0, second_angle_step, 0);
        Vector3 minute_rotation_step = new Vector3(0, (float)minute_angle_step, 0);
        Vector3 hour_rotation_step = new Vector3(0, (float)hour_angle_step, 0);

        second_pivot.transform.Rotate(second_rotation_step * Time.deltaTime * warp_factor);
        minute_pivot.transform.Rotate(minute_rotation_step * Time.deltaTime * warp_factor);
        hour_pivot.transform.Rotate(hour_rotation_step * Time.deltaTime * warp_factor);



    }

    void Tick_2(){
        float second_angle_step = 360 / 60;
        Vector3 second_rotation_step = new Vector3(0, second_angle_step, 0);
        elapsed += Time.deltaTime;
        if (elapsed > 1.0f){
            elapsed = elapsed % 1.0f;
            second_pivot.transform.Rotate(second_rotation_step);

        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Set_time(Get_time());
    }

    // Update is called once per frame
    void Update()
    {
        Tick();

        if (Time.deltaTime % 600 == 0){     //error correction every 10 minutes
            Set_time(Get_time());
        }
    }
}
