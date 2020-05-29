﻿using System.Collections.Generic;
using UnityEngine;

public class CrewMemberMovement : MonoBehaviour
{
    List<Vector3> movingPoints = new List<Vector3>();
    [SerializeField] float speed;

    int crossingPointToReach = 0;
    int nbOfCrossingPoints;
    bool hasToMove;

    void OnEnable()
    {
        hasToMove = true;
        GameObject crossingPointsParent = GameObject.Find("Crossing points");
        nbOfCrossingPoints = crossingPointsParent.transform.childCount;

        for (int i = 0; i < nbOfCrossingPoints; i++)
        {
            movingPoints.Add(crossingPointsParent.transform.GetChild(i).gameObject.transform.position);
        }

    }

    void Update()
    {
        if (hasToMove)
            MoveTowardPoint(movingPoints[crossingPointToReach]);

        if (Input.GetKeyDown(KeyCode.Space)) SendBack();

    }

    void MoveTowardPoint(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < .001f)
        {
            if (crossingPointToReach == 1 || crossingPointToReach == nbOfCrossingPoints - 1)
            {
                hasToMove = false;
            }
            else
            {
                crossingPointToReach++;
            }
        }
    }

    public void SendBack()
    {
        crossingPointToReach++;
        hasToMove = true;
    }
}