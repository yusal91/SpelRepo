using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float offSet;                                   //  bara offSet;
    public float offsetSmothing;                           // see i distance n�r beroend p� vilken h�ll man v�nder till,
    private Vector3 playerPostion;
      


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var xPos = Player.transform.position.x;
        var yPos = transform.position.y;
        var zPos = transform.position.z;
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
