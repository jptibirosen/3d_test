using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ts3_player_or_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string EntityType = "player";
        int HP;

        if (EntityType == "player") {
            HP = 50;
            Debug.Log("I am Player! My HP is 50!");
        } else{
            HP = 10;
            Debug.Log("I am Enenmy! My HP is 10!");
        }
        Debug.Log(HP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
