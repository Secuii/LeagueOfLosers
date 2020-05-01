using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour
{
    public GameObject[] patrolPoints = new GameObject[5];
    public NavMeshAgent NavAgent;
    public int actualPatrolPoint = 0;
    public int playerIndex;
    public bool detectDistance;
    public int minionDamage = 5;

    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (detectDistance)
        {
            if (Vector3.Distance(transform.position, patrolPoints[actualPatrolPoint].transform.position) <= 1f)
            {
                actualPatrolPoint++;

                if (actualPatrolPoint < patrolPoints.Length)
                {
                    MoveToNextPoint();
                }
            }
        }
    }

    private void MoveToNextPoint()
    {
        if(actualPatrolPoint < patrolPoints.Length)
        {
            NavAgent.SetDestination(patrolPoints[actualPatrolPoint].transform.position);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawn"))
        {
            if(other.transform.parent.GetComponent<CoreController>().playerIndex == playerIndex)
            {
                for (int i = 0; i < patrolPoints.Length; i++)
                {
                    patrolPoints[i] = other.transform.GetChild(0).transform.GetChild(i).gameObject;
                }
                detectDistance = true;
                MoveToNextPoint();
            }
        }

        if (other.CompareTag("Turret"))
        {
            if (other.GetComponent<TurretController>().playerIndex != playerIndex)
            {

                //shoot the turret
            }
        }
    }
    public void SetMinionIndex(int _index)
    {
        playerIndex = _index;
    }
}