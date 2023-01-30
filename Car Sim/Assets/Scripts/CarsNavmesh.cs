using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CarsNavmesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private Transform _targetPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetPoint)
        {
            agent.SetDestination(_targetPoint.transform.position);

            if ((transform.position - _targetPoint.transform.position).sqrMagnitude < 10)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Setup(Transform target)
    {
        _targetPoint = target;
    }
}

