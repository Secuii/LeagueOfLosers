using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public GameObject trigger;
    public GameObject projectile;
    public int playerIndex;
    public LayerMask mask;
    private bool isAttackAvailable = true;
    private float attackTime = 0f;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {

            if (Physics.Raycast(ray, out hit, 100 ,mask))
            {

                agent.isStopped = false;
                agent.SetDestination(hit.point);


            }
        }

        /// Attack
        ///
        ///
        /// 

        attackTime += Time.deltaTime;
        float attackSeconds = attackTime % 60f;
        if (attackSeconds >= 1)
        {
            isAttackAvailable = true;
        }
        
        if (isAttackAvailable)
        {
            attackTime = 0f;
            if (Input.GetKey(KeyCode.Alpha1))
            {

                isAttackAvailable = false;
                if (Physics.Raycast(ray, out hit, 100, mask))
                {
                    transform.LookAt(hit.point);
                    agent.isStopped = true;

                    GameObject newProjectile = Instantiate(projectile, trigger.transform.position, trigger.transform.rotation);
                    newProjectile.GetComponent<ProjectileController>().SetPlayerIndex(playerIndex);

                }
            }
        }
    }
}