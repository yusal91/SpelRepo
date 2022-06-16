using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerControl>().currentHealth +=amount;
        Debug.Log(target);        
        target.GetComponent<HealthBarScripts>().hpSlider.value = amount;
    }
}
