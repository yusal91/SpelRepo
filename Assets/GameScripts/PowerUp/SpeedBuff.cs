using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;
    public float dealy = 10f;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerControl>().moveSpeed += amount;
        target.GetComponent<SpriteRenderer>().color = Color.yellow;         
    }    

    //IEnumerator TemporarySpeedIncressed(GameObject player)
    //{
    //    player.GetComponent<PlayerControl>().moveSpeed += amount;
    //    player.GetComponent<SpriteRenderer>().color = Color.yellow;
    //    yield return new WaitForSeconds(dealy);
    //}

}
