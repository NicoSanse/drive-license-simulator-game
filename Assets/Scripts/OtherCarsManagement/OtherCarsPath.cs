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
    private static List<Vector3> firstPathReverse;
    private static List<Vector3> secondPathReverse;
    private static List<Vector3> thirdPathReverse;
    private static List<Vector3> fourthPathReverse;
    private static List<Vector3> fifthPathReverse;

    void Awake()
    {
        paths = new List<List<Vector3>>();
        firstPath = new List<Vector3>();
        secondPath = new List<Vector3>();
        thirdPath = new List<Vector3>();
        fourthPath = new List<Vector3>();
        fifthPath = new List<Vector3>();
        firstPathReverse = new List<Vector3>();
        secondPathReverse = new List<Vector3>();
        thirdPathReverse = new List<Vector3>();
        fourthPathReverse = new List<Vector3>();
        fifthPathReverse = new List<Vector3>();
        GenerateFirstPath();
        GenerateSecondPath();
        GenerateThirdPath();
        GenerateFourthPath();
        GenerateFifthPath();
        GenerateFirstPathReverse();
        GenerateSecondPathReverse();
        GenerateThirdPathReverse();
        GenerateFourthPathReverse();
        GenerateFifthPathReverse();
        paths.Add(firstPath);
        paths.Add(secondPath);
        paths.Add(thirdPath);
        paths.Add(fourthPath);
        paths.Add(fifthPath);
        paths.Add(firstPathReverse);
        paths.Add(secondPathReverse);
        paths.Add(thirdPathReverse);
        paths.Add(fourthPathReverse);
        paths.Add(fifthPathReverse);
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
        Vector3 tempWayPoint7 = new Vector3(913.5f, 1, 480);
        Vector3 tempWayPoint8 = new Vector3(933, 1, 499);
        Vector3 tempWayPoint9 = new Vector3(1030, 1, 499);
        Vector3 tempWayPoint10 = new Vector3(1053.5f, 1, 530);
        Vector3 tempWayPoint11 = new Vector3(1053.5f, 1, 870);
        Vector3 tempWayPoint12 = new Vector3(1030, 1, 895.5f);
        Vector3 tempWayPoint13 = new Vector3(458, 1, 895.5f);
        Vector3 tempWayPoint14 = new Vector3(439.5f, 1, 872);
        Vector3 tempWayPoint15 = new Vector3(439.5f, 1, 673);
        Vector3 tempWayPoint16 = new Vector3(427, 1, 663.5f);
        Vector3 tempWayPoint17 = new Vector3(12, 1, 663.5f);
        Vector3 tempWayPoint18 = new Vector3(0, 1, 648);
        Vector3 tempWayPoint19 = new Vector3(0, 1, 464);
        Vector3 tempWayPoint20 = new Vector3(0, 1, 403);
        Vector3 tempWayPoint21 = new Vector3(0, 1, 72);
        Vector3 tempWayPoint22 = new Vector3(16, 1, 56.5f);
        Vector3 tempWayPoint23 = new Vector3(297, 1, 56.5f);
        Vector3 tempWayPoint24 = new Vector3(307, 1, 70);
        secondPath.Add(tempWayPoint);
        secondPath.Add(tempWayPoint2);
        secondPath.Add(tempWayPoint3);
        secondPath.Add(tempWayPoint4);
        secondPath.Add(tempWayPoint5);
        secondPath.Add(tempWayPoint6);
        secondPath.Add(tempWayPoint7);
        secondPath.Add(tempWayPoint8);
        secondPath.Add(tempWayPoint9);
        secondPath.Add(tempWayPoint10);
        secondPath.Add(tempWayPoint11);
        secondPath.Add(tempWayPoint12);
        secondPath.Add(tempWayPoint13);
        secondPath.Add(tempWayPoint14);
        secondPath.Add(tempWayPoint15);
        secondPath.Add(tempWayPoint16);
        secondPath.Add(tempWayPoint17);
        secondPath.Add(tempWayPoint18);
        secondPath.Add(tempWayPoint19);
        secondPath.Add(tempWayPoint20);
        secondPath.Add(tempWayPoint21);
        secondPath.Add(tempWayPoint22);
        secondPath.Add(tempWayPoint23);
        secondPath.Add(tempWayPoint24);
    }

    private void GenerateThirdPath()
    {
        Vector3 tempWayPoint = new Vector3(-13, 1, 438.5f);
        Vector3 tempWayPoint2 = new Vector3(-281, 1, 438.5f);
        Vector3 tempWayPoint3 = new Vector3(-293.5f, 1, 452);
        Vector3 tempWayPoint4 = new Vector3(-293.5f, 1, 653);
        Vector3 tempWayPoint5 = new Vector3(-304, 1, 663.5f);
        Vector3 tempWayPoint6 = new Vector3(-580, 1, 663.5f);
        Vector3 tempWayPoint7 = new Vector3(-599.5f, 1, 648);
        Vector3 tempWayPoint8 = new Vector3(-599.5f, 1, 448);
        Vector3 tempWayPoint9 = new Vector3(-582, 1, 431.5f);
        Vector3 tempWayPoint10 = new Vector3(-304, 1, 431.5f);
        Vector3 tempWayPoint11 = new Vector3(-292.5f, 1, 444);
        Vector3 tempWayPoint12 = new Vector3(-292.5f, 1, 646);
        Vector3 tempWayPoint13 = new Vector3(-284, 1, 655.5f);
        Vector3 tempWayPoint14 = new Vector3(-10, 1, 655.5f);
        Vector3 tempWayPoint15 = new Vector3(0, 1, 645);
        Vector3 tempWayPoint16 = new Vector3(0, 1, 450);
        thirdPath.Add(tempWayPoint);
        thirdPath.Add(tempWayPoint2);
        thirdPath.Add(tempWayPoint3);
        thirdPath.Add(tempWayPoint4);
        thirdPath.Add(tempWayPoint5);
        thirdPath.Add(tempWayPoint6);
        thirdPath.Add(tempWayPoint7);
        thirdPath.Add(tempWayPoint8);
        thirdPath.Add(tempWayPoint9);
        thirdPath.Add(tempWayPoint10);
        thirdPath.Add(tempWayPoint11);
        thirdPath.Add(tempWayPoint12);
        thirdPath.Add(tempWayPoint13);
        thirdPath.Add(tempWayPoint14);
        thirdPath.Add(tempWayPoint15);
        thirdPath.Add(tempWayPoint16);
    }

    private void GenerateFourthPath()
    {
        
    }

    private void GenerateFifthPath()
    {
        
    }

    private void GenerateFirstPathReverse()
    {
        Vector3 tempWayPoint = new Vector3(299.5f, 1, 66);
        Vector3 tempWayPoint2 = new Vector3(312, 1, 56.5f);
        Vector3 tempWayPoint3 = new Vector3(515, 1, 56.5f);
        Vector3 tempWayPoint4 = new Vector3(531.5f, 1, 70);
        Vector3 tempWayPoint5 = new Vector3(531.5f, 1, 640);
        Vector3 tempWayPoint6 = new Vector3(548, 1, 656.5f);
        Vector3 tempWayPoint7 = new Vector3(740, 1, 656.5f);
        Vector3 tempWayPoint8 = new Vector3(767, 1, 649.5f);
        Vector3 tempWayPoint9 = new Vector3(876, 1, 649.5f);
        Vector3 tempWayPoint10 = new Vector3(892.5f, 1, 632);
        Vector3 tempWayPoint11 = new Vector3(892.5f, 1, 539);
        Vector3 tempWayPoint12 = new Vector3(892.5f, 1, 482);
        Vector3 tempWayPoint13 = new Vector3(892.5f, 1, 455);
        Vector3 tempWayPoint14 = new Vector3(874, 1, 445.5f);
        Vector3 tempWayPoint15 = new Vector3(616, 1, 445.5f);
        Vector3 tempWayPoint16 = new Vector3(592, 1, 438.5f);
        Vector3 tempWayPoint17 = new Vector3(312, 1, 438.5f);
        Vector3 tempWayPoint18 = new Vector3(299.5f, 1, 420);
        firstPathReverse.Add(tempWayPoint);
        firstPathReverse.Add(tempWayPoint2);
        firstPathReverse.Add(tempWayPoint3);
        firstPathReverse.Add(tempWayPoint4);
        firstPathReverse.Add(tempWayPoint5);
        firstPathReverse.Add(tempWayPoint6);
        firstPathReverse.Add(tempWayPoint7);
        firstPathReverse.Add(tempWayPoint8);
        firstPathReverse.Add(tempWayPoint9);
        firstPathReverse.Add(tempWayPoint10);
        firstPathReverse.Add(tempWayPoint11);
        firstPathReverse.Add(tempWayPoint12);
        firstPathReverse.Add(tempWayPoint13);
        firstPathReverse.Add(tempWayPoint14);
        firstPathReverse.Add(tempWayPoint15);
        firstPathReverse.Add(tempWayPoint16);
        firstPathReverse.Add(tempWayPoint17);
        firstPathReverse.Add(tempWayPoint18);
    }

    private void GenerateSecondPathReverse()
    {
        Vector3 tempWayPoint = new Vector3(299.5f, 1, 74);
        Vector3 tempWayPoint2 = new Vector3(290, 1, 63.5f);
        Vector3 tempWayPoint3 = new Vector3(19, 1, 63.5f);
        Vector3 tempWayPoint4 = new Vector3(6.5f, 1, 79);
        Vector3 tempWayPoint5 = new Vector3(6.5f, 1, 405);
        Vector3 tempWayPoint6 = new Vector3(6.5f, 1, 465);
        Vector3 tempWayPoint7 = new Vector3(6.5f, 1, 645);
        Vector3 tempWayPoint8 = new Vector3(18, 1, 656.5f);
        Vector3 tempWayPoint9 = new Vector3(429, 1, 656.5f);
        Vector3 tempWayPoint10 = new Vector3(446.5f, 1, 673);
        Vector3 tempWayPoint11 = new Vector3(446.5f, 1, 860);
        Vector3 tempWayPoint12 = new Vector3(459, 1, 880.5f);
        Vector3 tempWayPoint13 = new Vector3(1024, 1, 880.5f);
        Vector3 tempWayPoint14 = new Vector3(1039.5f, 1, 865);
        Vector3 tempWayPoint15 = new Vector3(1039.5f, 1, 527);
        Vector3 tempWayPoint16 = new Vector3(1025, 1, 513.5f);
        Vector3 tempWayPoint17 = new Vector3(912, 1, 513.5f);
        Vector3 tempWayPoint18 = new Vector3(899.5f, 1, 502);
        Vector3 tempWayPoint19 = new Vector3(898, 1, 448);
        Vector3 tempWayPoint20 = new Vector3(886, 1, 438.5f);
        Vector3 tempWayPoint21 = new Vector3(312, 1, 438.5f);
        Vector3 tempWayPoint22 = new Vector3(299.5f, 1, 420);
        secondPathReverse.Add(tempWayPoint);
        secondPathReverse.Add(tempWayPoint2);
        secondPathReverse.Add(tempWayPoint3);
        secondPathReverse.Add(tempWayPoint4);
        secondPathReverse.Add(tempWayPoint5);
        secondPathReverse.Add(tempWayPoint6);
        secondPathReverse.Add(tempWayPoint7);
        secondPathReverse.Add(tempWayPoint8);
        secondPathReverse.Add(tempWayPoint9);
        secondPathReverse.Add(tempWayPoint10);
        secondPathReverse.Add(tempWayPoint11);
        secondPathReverse.Add(tempWayPoint12);
        secondPathReverse.Add(tempWayPoint13);
        secondPathReverse.Add(tempWayPoint14);
        secondPathReverse.Add(tempWayPoint15);
        secondPathReverse.Add(tempWayPoint16);
        secondPathReverse.Add(tempWayPoint17);
        secondPathReverse.Add(tempWayPoint18);
        secondPathReverse.Add(tempWayPoint19);
        secondPathReverse.Add(tempWayPoint20);
        secondPathReverse.Add(tempWayPoint21);
        secondPathReverse.Add(tempWayPoint22);
    }

    private void GenerateThirdPathReverse()
    { 
        Vector3 tempWayPoint = new Vector3(-3, 1, 431.5f);
        Vector3 tempWayPoint2 = new Vector3(7, 1, 440);
        Vector3 tempWayPoint3 = new Vector3(7, 1, 654);
        Vector3 tempWayPoint4 = new Vector3(-3, 1, 663.5f);
        Vector3 tempWayPoint5 = new Vector3(-287, 1, 663.5f);
        Vector3 tempWayPoint6 = new Vector3(-300.5f, 1, 650);
        Vector3 tempWayPoint7 = new Vector3(-300.5f, 1, 450);
        Vector3 tempWayPoint8 = new Vector3(-312, 1, 438.5f);
        Vector3 tempWayPoint9 = new Vector3(-582, 1, 438.5f);
        Vector3 tempWayPoint10 = new Vector3(-592.5f, 1, 450);
        Vector3 tempWayPoint11 = new Vector3(-592.5f, 1, 645);
        Vector3 tempWayPoint12 = new Vector3(-582, 1, 656.5f);
        Vector3 tempWayPoint13 = new Vector3(-312, 1, 656.5f);
        Vector3 tempWayPoint14 = new Vector3(-300.5f, 1, 644);
        Vector3 tempWayPoint15 = new Vector3(-300.5f, 1, 444);
        Vector3 tempWayPoint16 = new Vector3(-288, 1, 431.5f);
        thirdPathReverse.Add(tempWayPoint);
        thirdPathReverse.Add(tempWayPoint2);
        thirdPathReverse.Add(tempWayPoint3);
        thirdPathReverse.Add(tempWayPoint4);
        thirdPathReverse.Add(tempWayPoint5);
        thirdPathReverse.Add(tempWayPoint6);
        thirdPathReverse.Add(tempWayPoint7);
        thirdPathReverse.Add(tempWayPoint8);
        thirdPathReverse.Add(tempWayPoint9);
        thirdPathReverse.Add(tempWayPoint10);
        thirdPathReverse.Add(tempWayPoint11);
        thirdPathReverse.Add(tempWayPoint12);
        thirdPathReverse.Add(tempWayPoint13);
        thirdPathReverse.Add(tempWayPoint14);
        thirdPathReverse.Add(tempWayPoint15);
        thirdPathReverse.Add(tempWayPoint16);
    }

    private void GenerateFourthPathReverse()
    { 

    }

    private void GenerateFifthPathReverse()
    { 

    }

    public static List<Vector3> GetAPath(int index)
    {
        return paths[index];
    }
    
}