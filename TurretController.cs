using System;
using System.Collections;
using UnityEngine;


public class TurretController : MonoBehaviour
{
    public int playerIndex;
    private int life = 100;


    public void DealingDamage(int _lifeDown)
    {
        life -= _lifeDown;
        Debug.Log("bajando vida");
        if(life <= 0)
        {
            Destroy(this.gameObject);

        }
    }
}