using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateChecker : MonoBehaviour
{
    string Coordinate;
    public IsItMatch Match;
    public CreateHexagon CreateHex;
    public StartCheck CheckFirst;


    void Start()
    {
        CreateHex.CreateHexagons();
        //CheckFirst.AreThereAnyLeft();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckFirst.AreThereAny();
    }

    //public void MatchFinder() //Her Hex'i tek tek gezecek ve yeniden isimlendirecek.
    //{
    //    for (int x = 0; x < 8; x++)
    //    {
    //        for (int y = 0; y < 9; y++)
    //        {
    //            Coordinate = "" + x + "." + y;
    //            GameObject Wanted = GameObject.Find(Coordinate);
    //        }
    //    }
    //}
}
