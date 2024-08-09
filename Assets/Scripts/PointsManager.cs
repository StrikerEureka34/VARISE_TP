using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class PointsManager : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsDisplay; // Use TextMeshProUGUI

    public void Points()
    {
        points += 10;
        Debug.Log(points);
        pointsDisplay.text = points.ToString();
    }
}