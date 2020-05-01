using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private int damage = 2;
    private int playerIndex;
    private float projectileSpeed = 8f;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Turret"))
        {
            if(other.transform.parent.GetComponent<TurretController>().playerIndex != playerIndex)
            {
                other.transform.parent.GetComponent<TurretController>().DealingDamage(damage);
            }
        }
    }

    public void SetPlayerIndex (int _index)
    {
        playerIndex = _index;
    }

    public void SetProjectileSpeed(int _speed)
    {
        projectileSpeed = _speed;
    }
}