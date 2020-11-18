using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class TouchedTwo : MonoBehaviour
{
    public GameObject border, SecondHex, ThirdHex, FirstGameObject, SecondGameObject, ThirdGameObject, GroupControl;
    float FirstHexCoordinate, HexXFloat, HexYFloat, HexX, HexY;
    string SecondHexCoordinateString, FirstCoordinate, SecondCoordinate, ThirdCoordinate;
    public int sayac = 0, FirstHexCoordinatex, FirstHexCoordinateInt, FirstHexCoordinatey, SecondHexCoordinatex, SecondHexCoordinatey, ThirdHexCoordinatex, ThirdHexCoordinatey;
    TouchedThree hexthree;
    SwipeControl IsItSwiping;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    GameObject[] GroupControlTag = { };

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp() // 2,3 noktası için 3,2 ve 3,3'ü seçmeli. Yani +1,-1 & +1,0
    {
        GroupControl = new GameObject
        {
            name = "NewParenHex"
        };

        GroupControlTag = GameObject.FindGameObjectsWithTag("GroupControl");

        for (int counter = 0; counter < GroupControlTag.Length; counter++)
        {
            GroupControlTag[counter].transform.gameObject.tag = "ThereIsNothing";
        }

        GroupControl.transform.gameObject.tag = "GroupControl";

        if (transform.position.y < 5.97 & transform.position.y > 0) //Alt Üst sınır kontrolü
        {
            if (transform.position.x < 4.26) //Sağ sınır kontrolü
            {
                Destroy(GameObject.FindWithTag("Border1"));

                //Debug.Log("click 2");
                GameObject myBorder = GameObject.Instantiate(border, new Vector3(transform.position.x + 0.308f, transform.position.y, -0.13f), transform.rotation * Quaternion.Euler(0f, 180f, 0f));

                FirstHexCoordinate = float.Parse(transform.parent.name, CultureInfo.InvariantCulture.NumberFormat);
                //Debug.Log(transform.parent.name);
                if (FirstHexCoordinate < 1)
                {
                    //Debug.Log(FirstHexCoordinate);
                    FirstHexCoordinatex = 0;
                    FirstHexCoordinate *= 10;
                    FirstHexCoordinatey = (int)FirstHexCoordinate;
                }
                else
                {
                    //Debug.Log(FirstHexCoordinate);
                    FirstHexCoordinate *= 10;
                    FirstHexCoordinateInt = (int)FirstHexCoordinate;
                    FirstHexCoordinatey = (FirstHexCoordinateInt) % 10;
                    FirstHexCoordinatex = FirstHexCoordinateInt / 10;
                }

                ThirdHexCoordinatex = FirstHexCoordinatex + 1;
                ThirdHexCoordinatey = FirstHexCoordinatey;

                SecondHexCoordinatex = FirstHexCoordinatex + 1;
                SecondHexCoordinatey = FirstHexCoordinatey - 1;

                if (FirstHexCoordinatex % 2 == 1)
                {
                    ThirdHexCoordinatey = FirstHexCoordinatey + 1;
                    SecondHexCoordinatey = FirstHexCoordinatey;
                }
                SecondHex = GameObject.Find(SecondHexCoordinateString);

                //Debug.Log(FirstHexCoordinatex);
                //Debug.Log(FirstHexCoordinatey);
                //Debug.Log(SecondHexCoordinatex);
                //Debug.Log(SecondHexCoordinatey);
                //Debug.Log(ThirdHexCoordinatex);
                //Debug.Log(ThirdHexCoordinatey);

                FirstCoordinate = "" + FirstHexCoordinatex + "." + FirstHexCoordinatey;
                SecondCoordinate = "" + SecondHexCoordinatex + "." + SecondHexCoordinatey;
                ThirdCoordinate = "" + ThirdHexCoordinatex + "." + ThirdHexCoordinatey;

                FirstGameObject = GameObject.Find(FirstCoordinate);
                SecondGameObject = GameObject.Find(SecondCoordinate);
                ThirdGameObject = GameObject.Find(ThirdCoordinate);

                HexX = FirstGameObject.transform.position.x + SecondGameObject.transform.position.x + ThirdGameObject.transform.position.x;
                HexY = FirstGameObject.transform.position.y + SecondGameObject.transform.position.y + ThirdGameObject.transform.position.y;
                HexXFloat = (HexX) / 3.0f;
                HexYFloat = (HexY) / 3.0f;
                //Debug.Log(HexXFloat);
                //Debug.Log(HexYFloat);

                //GameObject MyGroupControl = 
                //Instantiate(GroupControl, new Vector3(0, 0, -0.13f), Quaternion.identity);
                GroupControl.name = "NewParenHex";
                //Debug.Log("NewParentHex oluşturuldu");

                GroupControl.transform.position = new Vector3(HexXFloat, HexYFloat, 0);

                FirstGameObject.transform.parent = GroupControl.transform; //ParentHex, Hex1'in parent'ı oluyor.
                SecondGameObject.transform.parent = GroupControl.transform; //ParentHex, Hex2'nin parent'ı oluyor.
                ThirdGameObject.transform.parent = GroupControl.transform; //ParentHex, Hex3'ün parent'ı oluyor.
                myBorder.transform.parent = GroupControl.transform; //Parenthex, Border'ın parent'ı oluyor.

                // objectA.transform.parrent = objectB.transform; yazdığına göre aşağısı böyle değişecek.
                //if () // Döndürdün ve renkler eşleşiyorsa null yap
                //{
                //for (int i = objectB.transform.childCount - 1; i >= 0; i--)
                //{
                //    // objectA is not the attached GameObject, so you can do all your checks with it.
                //    objectA = objectB.transform.getChild(i);
                //    objectA.transform.parrent = null;
                //    // Optionally destroy the objectA if not longer needed
                //}
                //}
            }
            else
            {
                Destroy(GameObject.FindWithTag("Border1"));

                //Debug.Log("Yine bir şey olmadı");
            }
        }

        else
        {
            Destroy(GameObject.FindWithTag("Border1"));

            //Debug.Log("Bir şey olmadı");
        }
    }
}
