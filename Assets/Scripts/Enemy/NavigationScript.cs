using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    public Transform enemyTarget;
    private NavMeshAgent agent;
    
    private Enemy enemy;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
        agent.destination = enemyTarget.position;
    }

    private void Update()
    {
        agent.destination = enemyTarget.position;
    }
}
