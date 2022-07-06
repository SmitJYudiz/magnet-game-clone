using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcBehaviour : MonoBehaviour
{
    //smit's work

    public LineRenderer arcLine;

    public Transform point1;
    public Transform point2;
    public Transform point3;

    public float vertexCount = 12;

    private void Start()
    {
        
    }

    private void Update()
    {
        var pointList = new List<Vector3>();

        for(float ratio = 0; ratio<=1; ratio += 1/vertexCount)
        {
            var tangent1 = Vector3.Lerp(point1.position, point2.position, ratio);
            var tangent2 = Vector3.Lerp(point2.position, point3.position, ratio);
            var curve = Vector3.Lerp(tangent1, tangent2, ratio);

            pointList.Add(curve);

        }

        arcLine.positionCount = pointList.Count;
        arcLine.SetPositions(pointList.ToArray());

    }


    public void SetThirdPointPosition(Vector3 target)
    {
        point3.SetPositionAndRotation(target, Quaternion.identity);
            
    }

    //first point will be the origin, so it will be equal to the magnet's position

    //second point will be used as middle point, to set/change the height from in between

    //third point will be the end of the arc line
}
