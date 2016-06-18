using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject carObject;
    public Transform cameraSets;

    public Transform targetLookat;
    public Transform targetPosition;
    public Transform raycastEnd;

    public float moveSmoothness = 2f;
    public float rotateSmoothness = 2f;

    public LayerMask layerMasks;


    void LateUpdate()
    {
        cameraSets.position = carObject.transform.position;

        float rotSmooth = 1f + 5f * rotateSmoothness;


        cameraSets.rotation = Quaternion.Lerp(cameraSets.rotation, carObject.transform.rotation, rotSmooth * Time.deltaTime);

        float yPosition = Mathf.Lerp(transform.position.y, targetPosition.position.y, moveSmoothness * Time.deltaTime);
        Vector3 newPosition = new Vector3(targetPosition.position.x, yPosition, targetPosition.position.z);

        RaycastHit wallHit = new RaycastHit();

        if (Physics.Linecast(targetLookat.position, raycastEnd.position, out wallHit, layerMasks))
        {
            Vector3 hitPoint = wallHit.point + 0.5f * wallHit.normal.normalized;

            newPosition.x = hitPoint.x; newPosition.z = hitPoint.z;
            //Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
        }

        transform.position = newPosition;

        var quaterion = Quaternion.LookRotation(targetLookat.position - transform.position);
        transform.rotation = quaterion;
    }
}
