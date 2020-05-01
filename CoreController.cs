using UnityEngine;

public class CoreController : MonoBehaviour
{
    
    public int playerIndex;
    private GameObject turret1;
    private GameObject turret2;
    private int life = 100;

    private void Start()
    {
        turret1 = transform.GetChild(3).gameObject;
        turret2 = transform.GetChild(4).gameObject;
    }


    public void DealingDamage(int _lifeDown)
    {
        if( turret1 == null && turret2 == null)
        {
            life -= _lifeDown;
            if (life <= 0)
            {
                GameManager.GameFinish(playerIndex);

            }
        }
    }
}