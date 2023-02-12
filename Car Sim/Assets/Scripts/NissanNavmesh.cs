using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NissanNavmesh : MonoBehaviour
{
    [SerializeField] private GameObject go;

    private Transform _targetPoint;

    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = go.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetPoint)
        {
            _agent.SetDestination(_targetPoint.transform.position);

            if ((transform.position - _targetPoint.transform.position).sqrMagnitude < 10)
            {
                Destroy(go);
            }

            transform.position = go.transform.position;
        }
    }

    public void Setup(Transform target)
    {
        _targetPoint = target;
    }
}