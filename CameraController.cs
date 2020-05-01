using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        
    }

    private void Move()
    {

        transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.5f);

    }
}