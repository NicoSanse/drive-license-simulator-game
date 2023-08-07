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
        Vector3 point5 = new Vector3(-293, 1, 462);
        Vector3 point6 = new Vector3(-293, 1, 635);
        Vector3 point7 = new Vector3(-265, 1, 656);
        Vector3 point8 = new Vector3(-30, 1, 656);
        Vector3 point9 = new Vector3(0, 1, 632);
        Vector3 point10 = new Vector3(0, 1, 455);
        Vector3 point11 = new Vector3(0, 1, 80);
        Vector3 point12 = new Vector3(272, 1, 56);
        Vector3 point13 = new Vector3(304, 1, 75);
        Vector3 point14 = new Vector3(304, 1, 162);
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
        firstPlayerPath.Add(point11);
        firstPlayerPath.Add(point12);
        firstPlayerPath.Add(point13);
        firstPlayerPath.Add(point14);
    }

    private void BuildSecondPlayerPath()
    {
        Vector3 point1 = new Vector3(307, 1, 420);
        Vector3 point2 = new Vector3(280, 1, 440);
        Vector3 point3 = new Vector3(185, 1, 440);
        Vector3 point4 = new Vector3(157, 1, 450);
        Vector3 point5 = new Vector3(157, 1, 570);
        Vector3 point6 = new Vector3(138, 1, 588);
        Vector3 point7 = new Vector3(35, 1, 588);
        Vector3 point8 = new Vector3(7, 1, 600);
        Vector3 point9 = new Vector3(7, 1, 778);
        Vector3 point10 = new Vector3(35, 1, 945);
        Vector3 point11 = new Vector3(274, 1, 956);
        Vector3 point12 = new Vector3(300, 1, 945);
        Vector3 point13 = new Vector3(300, 1, 692);
        Vector3 point14 = new Vector3(300, 1, 605);
        Vector3 point15 = new Vector3(180, 1, 588);
        Vector3 point16 = new Vector3(149, 1, 570);
        Vector3 point17 = new Vector3(149, 1, 466);
        Vector3 point18 = new Vector3(168, 1, 431);
        Vector3 point19 = new Vector3(271, 1, 431);
        Vector3 point20 = new Vector3(300, 1, 420);
        Vector3 point21 = new Vector3(292, 1, 152);
        secondPlayerPath.Add(point1);
        secondPlayerPath.Add(point2);
        secondPlayerPath.Add(point3);
        secondPlayerPath.Add(point4);
        secondPlayerPath.Add(point5);
        secondPlayerPath.Add(point6);
        secondPlayerPath.Add(point7);
        secondPlayerPath.Add(point8);
        secondPlayerPath.Add(point9);
        secondPlayerPath.Add(point10);
        secondPlayerPath.Add(point11);
        secondPlayerPath.Add(point12);
        secondPlayerPath.Add(point13);
        secondPlayerPath.Add(point14);
        secondPlayerPath.Add(point15);
        secondPlayerPath.Add(point16);
        secondPlayerPath.Add(point17);
        secondPlayerPath.Add(point18);
        secondPlayerPath.Add(point19);
        secondPlayerPath.Add(point20);
        secondPlayerPath.Add(point21);
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
