using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoodGuy : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 goal;
    private NavMeshAgent _agent;
    public Camera Cam;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            goal= Input.mousePosition;
            if( Physics.Raycast(ray, out hit) )
            {
                Debug.Log(hit.point);
                _agent.destination = hit.point; 
            }
        }
    }
}
