using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Transform[] teleportPoints;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject loopThree;
    [SerializeField] private GameObject loopFour;
    [SerializeField] private GameObject loopFourChase;
    [SerializeField] private GameObject speedToggle;
    public float slowChaseSpeed;
    public float fastChaseSpeed;

    private NavMeshAgent agent;
    private int currentPatrolIndex = 0;
    private int currentTeleportIndex = 0;
    private bool isTeleporting = false;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (loopThree.activeInHierarchy)
        {
            Patrol();
            if (!isTeleporting) 
            {
                isTeleporting = true;
                StartCoroutine(Teleport());
            }
            if (player != null)
            {
                bool inRange = Vector3.Distance(transform.position, player.position) < 1.2f;
                if (inRange)
                {
                    StartCoroutine(LookAtPlayer());
                    StartCoroutine(JumpScare());
                    
                }
            }
        }
        else if (loopFour.activeInHierarchy || loopFourChase.activeInHierarchy)
        {
            agent.speed = slowChaseSpeed;
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                Chase();
                if (speedToggle.activeInHierarchy)
                {
                agent.speed = fastChaseSpeed;
                }
            }
            if (player != null)
            {
                bool inRange = Vector3.Distance(transform.position, player.position) < 1.2f;
                if (inRange)
                {
                    StartCoroutine(LookAtPlayer());
                    StartCoroutine(JumpScare());
                    
                }
            }
        }
    }
    private void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPatrolPoint();
        }
    }
    private void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        Debug.Log("Choosing patrol point " + currentPatrolIndex);
    }
    IEnumerator Teleport()
    {
        currentTeleportIndex = Random.Range(0, teleportPoints.Length);
        Vector3 randomPosition = teleportPoints[currentTeleportIndex].position;
        agent.Warp(randomPosition);
        int waitTime = Random.Range(5, 20);
        yield return new WaitForSecondsRealtime(waitTime);
        isTeleporting = false;
    }
    IEnumerator LookAtPlayer()
    {
        Vector3 lookPosition = player.position - transform.position;
        lookPosition.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        yield return new WaitForSecondsRealtime(2);
    }
    IEnumerator JumpScare()
    {
        Vector3 jumpScarePosition = player.position + player.forward * 0.5f;
        agent.Warp(jumpScarePosition);
        yield return new WaitForSecondsRealtime(1);
        deathScreen.SetActive(true);
        yield return null;
    }
    private void Chase()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
            Debug.Log("Chasing the player");
        }
    }
}
