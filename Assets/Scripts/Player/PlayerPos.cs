using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("playerCharacter");
        
    }


    // Update is called once per frame
    void Update()
    {
        
        if (player != null) 
        {
            //Debug.Log(player.transform.position.x);
        }
        
    }
}
