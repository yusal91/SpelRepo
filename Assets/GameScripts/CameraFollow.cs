using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float offSet;                                   //  bara offSet;
    public float offsetSmothing;                           // see i distance när beroend på vilken håll man vänder till,
    private Vector3 playerPostion;
      


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var xPos = Player.transform.position.x;                 //camera följer spelare i x axel
        var yPos = Player.transform.position.y;                 //camera följer spelare up i Y axel
        var zPos = transform.position.z;                        // inga rörelse i Z axel,
        playerPostion = new Vector3(xPos, yPos, zPos);           

        if(Player.transform.localScale.x > 0f)
        {
            playerPostion = new Vector3(playerPostion.x + offSet, playerPostion.y, playerPostion.z);
        }
        else
        {
            playerPostion = new Vector3(playerPostion.x - offSet, playerPostion.y, playerPostion.z); 
        }

        transform.position = Vector3.Lerp(transform.position, playerPostion, offsetSmothing * Time.deltaTime);
    }

    
}
