using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollSystem : MonoBehaviour
{
    [Header("-----Deteccion-----")]
    [SerializeField] private Enemy mainScript;
    [SerializeField] private float detectionRadius;
    [SerializeField] private float angleVision;
    [SerializeField] private LayerMask whatIsTarget;
    [SerializeField] private LayerMask whatIsObstacle;
    [Header("-----Patrulla-----")]
    [SerializeField] private float patrollVelocity;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform route;
    private List<Vector3> waypointsList = new List<Vector3>();
    private int actualIndexDestination = -1;
    private Vector3 actualDestination;


    private void Awake()
    {
        mainScript.Patroll = this;

        foreach (Transform wayPoint in route)
        {
            waypointsList.Add(wayPoint.position);
        }
    }
    private void OnEnable()
    {
        agent.stoppingDistance = 0;
        agent.speed = patrollVelocity;
        StartCoroutine(PatrollAndWait());
    }
    private void OnDisable()
    {
        StopCoroutine(PatrollAndWait());
    }
    private void FixedUpdate()
    {
        DetectTarget();
    }

    private void DetectTarget()
    {
        Collider[] collDetected = Physics.OverlapSphere(transform.position, detectionRadius, whatIsTarget);

        if (collDetected.Length > 0) //Player in range
        {
            mainScript.Target = collDetected[0].transform;
            Vector3 directionToTarget = (mainScript.Target.transform.position - transform.position);
            //Tirar un raycast desde mi posición al target y ver que NO haya obstáculos de por medio.
            if (!Physics.Raycast(transform.position, directionToTarget, detectionRadius, whatIsObstacle)) //No hay obstáculos de mi a player.
            {
                if (Vector3.Angle(directionToTarget, transform.forward) < angleVision / 2)
                {
                    mainScript.ActiveCombat(mainScript.Target);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Cono de visión
        Vector3 forward = transform.forward * detectionRadius;
        Vector3 leftBoundary = Quaternion.Euler(0, -angleVision / 2, 0) * forward;
        Vector3 rightBoundary = Quaternion.Euler(0, angleVision / 2, 0) * forward;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
    private IEnumerator PatrollAndWait()
    {
        while (true)
        {
            CalculateDestination();
            agent.SetDestination(actualDestination);

            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            yield return new WaitForSeconds(Random.Range(0.25f, 2f));
        }
    }

    private void CalculateDestination()
    {
        actualIndexDestination++;

        if (actualIndexDestination >= waypointsList.Count)
        {
            actualIndexDestination = 0;
        }

        actualDestination = waypointsList[actualIndexDestination];
    }
}
