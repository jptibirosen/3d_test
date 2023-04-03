using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ts2_conditionals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string test1 = "something";
        string test2 = "something";

        Debug.Log(test1 == test2);
        bool the_truth = test1 == test2;
        Debug.Log(the_truth);



        float temp_oulu = 2.6f;
        float temp_ivalo = -10.0f;

        if (temp_oulu < temp_ivalo) {
            Debug.Log("it is warmer in ivalo");
        }
        else if (temp_oulu > temp_ivalo) {
            Debug.Log("it is warmer in oulu");
        } else {
            Debug.Log("it is the same temperature in oulu and ivalo");
        }




        float temperature = 67.4f;

        string msg_over_110 = "over 110";
        string msg_over_90 = "over 90";
        string msg_over_70 = "over 70";
        string msg_over_50 = "over 50";
        string msg_over_30 = "over 30";
        string msg_over_10 = "over 10";

        if (temperature >= 110) {
            Debug.Log(msg_over_110);
        }
        else if (temperature >= 90) {
            Debug.Log(msg_over_90);
        }
        else if (temperature >= 70) {
            Debug.Log(msg_over_70);
        }
        else if (temperature >= 50) {
            Debug.Log(msg_over_50);
        }
        else if (temperature >= 30) {
            Debug.Log(msg_over_30);
        }
        else if (temperature >= 10) {
            Debug.Log(msg_over_10);
        }else{
            Debug.Log("turn on your sauna!");
        }





        //string entity_type;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
