using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int points = 0;

    public void Points()
    {
        points = points + 10;
        Debug.Log("points=" + points);
    }
}
