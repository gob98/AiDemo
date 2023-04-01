using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public float timer, WanderTime;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit))
            SetAiTargetLocation(hit.point);
        }
        timer += Time.deltaTime;
        Wander();
    }

    private void SetAiTargetLocation(Vector3 targetLocation)
    {
        _navMeshAgent.SetDestination(targetLocation);
    }
    private void Wander()
    {
        if (timer <= WanderTime)
        {


            Vector2 wanderTarget = Random.insideUnitCircle * WanderTime;
            Vector3 wanderPos3D = new Vector3(transform.position.x + wanderTarget.x, transform.position.y, transform.position.z + wanderTarget.y);
            SetAiTargetLocation(wanderPos3D);
            timer = 0;
        }
    }

}
