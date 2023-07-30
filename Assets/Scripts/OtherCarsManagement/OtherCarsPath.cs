using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarsPath : MonoBehaviour
{
    private static List<List<Vector3>> paths;
    private static List<Vector3> firstPath;
    private static List<Vector3> secondPath;
    private static List<Vector3> thirdPath;
    private static List<Vector3> fourthPath;
    private static List<Vector3> fifthPath;

    void Awake()
    {
        paths = new List<List<Vector3>>();
        firstPath = new List<Vector3>();
        secondPath = new List<Vector3>();
        thirdPath = new List<Vector3>();
        fourthPath = new List<Vector3>();
        fifthPath = new List<Vector3>();
        GenerateFirstPath();
        GenerateSecondPath();
        GenerateThirdPath();
        GenerateFourthPath();
        GenerateFifthPath();
        paths.Add(firstPath);
        paths.Add(secondPath);
        paths.Add(thirdPath);
        paths.Add(fourthPath);
        paths.Add(fifthPath);
    }

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void GenerateFirstPath()
    {
        Vector3 tempWayPoint = new Vector3(307, 1, 420);
        Vector3 tempWayPoint2 = new Vector3(320, 1, 431);
        Vector3 tempWayPoint3 = new Vector3(888, 1, 431);
        Vector3 tempWayPoint4 = new Vector3(907, 1, 450); 
        Vector3 tempWayPoint5 = new Vector3(907, 1, 478);
        Vector3 tempWayPoint6 = new Vector3(907, 1, 645);
        Vector3 tempWayPoint7 = new Vector3(888, 1, 663.5f);
        Vector3 tempWayPoint8 = new Vector3(545, 1, 663.5f);
        Vector3 tempWayPoint9 = new Vector3(524.5f, 1, 640);
        Vector3 tempWayPoint10 = new Vector3(524.5f, 1, 80);
        Vector3 tempWayPoint11 = new Vector3(510, 1, 63.5f);
        Vector3 tempWayPoint12 = new Vector3(324, 1, 63.5f);
        Vector3 tempWayPoint13 = new Vector3(307, 1, 80);
        firstPath.Add(tempWayPoint);
        firstPath.Add(tempWayPoint2);
        firstPath.Add(tempWayPoint3);
        firstPath.Add(tempWayPoint4);
        firstPath.Add(tempWayPoint5);
        firstPath.Add(tempWayPoint6);
        firstPath.Add(tempWayPoint7);
        firstPath.Add(tempWayPoint8);
        firstPath.Add(tempWayPoint9);
        firstPath.Add(tempWayPoint10);
        firstPath.Add(tempWayPoint11);
        firstPath.Add(tempWayPoint12);
        firstPath.Add(tempWayPoint13);
    }

    private void GenerateSecondPath()
    {
        Vector3 tempWayPoint = new Vector3(307, 1, 420);
        Vector3 tempWayPoint2 = new Vector3(320, 1, 431);
        Vector3 tempWayPoint3 = new Vector3(590, 1, 431);
        Vector3 tempWayPoint4 = new Vector3(615, 1, 424);
        Vector3 tempWayPoint5 = new Vector3(888, 1, 424);
        Vector3 tempWayPoint6 = new Vector3(913.5f, 1, 450);
        Vector3 tempWayPoint7 = new Vector3(913.5f, 1, 478);
        secondPath.Add(tempWayPoint);
        secondPath.Add(tempWayPoint2);
        secondPath.Add(tempWayPoint3);
        secondPath.Add(tempWayPoint4);
        secondPath.Add(tempWayPoint5);
        secondPath.Add(tempWayPoint6);
        secondPath.Add(tempWayPoint7);
    }

    private void GenerateThirdPath()
    {
        Vector3 tempWayPoint = new Vector3(307, 1, 420);
        Vector3 tempWayPoint2 = new Vector3(320, 1, 431);
        Vector3 tempWayPoint3 = new Vector3(590, 1, 431);
        thirdPath.Add(tempWayPoint);
        thirdPath.Add(tempWayPoint2);
        thirdPath.Add(tempWayPoint3);
    }

    private void GenerateFourthPath()
    {
        Vector3 tempWayPoint = new Vector3(307, 1, 420);
        Vector3 tempWayPoint2 = new Vector3(320, 1, 431);
        Vector3 tempWayPoint3 = new Vector3(590, 1, 431);
        fourthPath.Add(tempWayPoint);
        fourthPath.Add(tempWayPoint2);
        fourthPath.Add(tempWayPoint3);
    }

    private void GenerateFifthPath()
    {
        Vector3 tempWayPoint = new Vector3(307, 1, 420);
        Vector3 tempWayPoint2 = new Vector3(320, 1, 431);
        Vector3 tempWayPoint3 = new Vector3(590, 1, 431);
        fifthPath.Add(tempWayPoint);
        fifthPath.Add(tempWayPoint2);
        fifthPath.Add(tempWayPoint3);
    }

    public static List<Vector3> GetAPath(int index)
    {
        return paths[index];
    }
    
}
