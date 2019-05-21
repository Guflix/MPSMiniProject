using UnityEngine;
using System.Collections;


public class CamController : MonoBehaviour
{
    Vector3 newPosition;
    RaycastHit hit;
    Vector3 targetPos;
    void Start ()
	{
    }

    void Update()
    {
        Camera cam = GetComponent<Camera>();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);


        if (Input.GetAxis ("Mouse ScrollWheel") > 0) //zoom in
        {
            cam.transform.position += (targetPos - transform.position) / 5f;

            //transform.position = new Vector3(transform.position.x, transform.position.y - 60f, transform.position.z);
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0) //zoom out
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + 60f, transform.position.z);

        }

        if (Physics.Raycast(ray, out hit))
        {
            targetPos = hit.point;
        }
    }
}
