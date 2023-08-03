using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class contains the paths for each level
//from player controller class the path is picked
//the number is of path is written in Unity editor

public class PlayerPaths : MonoBehaviour
{
    private static List<List<Vector3>> paths;
    private List<Vector3> firstPlayerPath;
    private List<Vector3> secondPlayerPath;
    private List<Vector3> thirdPlayerPath;
    private List<Vector3> fourthPlayerPath;
    private List<Vector3> fifthPlayerPath;

    void Awake()
    {
        paths = new List<List<Vector3>>();
        firstPlayerPath = new List<Vector3>();
        secondPlayerPath = new List<Vector3>();
        thirdPlayerPath = new List<Vector3>();
        fourthPlayerPath = new List<Vector3>();
        fifthPlayerPath = new List<Vector3>();
        BuildFirstPlayerPath();
        BuildSecondPlayerPath();
        BuildThirdPlayerPath();
        BuildFourthPlayerPath();
        BuildFifthPlayerPath();
        paths.Add(firstPlayerPath);
        paths.Add(secondPlayerPath);
        paths.Add(thirdPlayerPath);
        paths.Add(fourthPlayerPath);
        paths.Add(fifthPlayerPath);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void BuildFirstPlayerPath()
    { 
        Vector3 point1 = new Vector3(307, 1, 420);
        Vector3 point2 = new Vector3(280, 1, 440);
        Vector3 point3 = new Vector3(30, 1, 440);
        Vector3 point4 = new Vector3(-280, 1, 440);
        Vector3 point5 = new Vector3(-293, 1, 635);
        Vector3 point6 = new Vector3(6, 1, 655);
        Vector3 point7 = new Vector3(6, 1, 455);
        Vector3 point8 = new Vector3(6, 1, 80);
        Vector3 point9 = new Vector3(305, 1, 57);
        Vector3 point10 = new Vector3(307, 1, 130);
        firstPlayerPath.Add(point1);
        firstPlayerPath.Add(point2);
        firstPlayerPath.Add(point3);
        firstPlayerPath.Add(point4);
        firstPlayerPath.Add(point5);
        firstPlayerPath.Add(point6);
        firstPlayerPath.Add(point7);
        firstPlayerPath.Add(point8);
        firstPlayerPath.Add(point9);
        firstPlayerPath.Add(point10);
    }

    private void BuildSecondPlayerPath()
    { 

    }

    private void BuildThirdPlayerPath()
    { 

    }

    private void BuildFourthPlayerPath()
    { 

    }

    private void BuildFifthPlayerPath()
    { 

    }

    public static List<Vector3> GetPlayerPath(int pathNumber)
    { 
        return paths[pathNumber];
    }
}
