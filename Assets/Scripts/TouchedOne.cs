using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class TouchedOne : MonoBehaviour
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

    GameObject[] GroupControlTag = {};

    /* 
     * transform.SetParent(col.transform);
    */

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnMouseUp()
    {
        //GameObject NewParentHex =  GameObject.Find("NewParenHex");
        //NewParentHex.transform.parent = null;

        //NewParentHex = GameObject.Find("NewParenHex(Clone)");
        //NewParentHex.transform.parent = null;

        //Destroy(GameObject.Find("NewParenHex(Clone)"));
        //Destroy(GameObject.Find("NewParenHex"));

        GroupControl = new GameObject
        {
            name = "NewParenHex"
        };

        GroupControlTag = GameObject.FindGameObjectsWithTag("GroupControl");

        for(int counter = 0; counter < GroupControlTag.Length; counter++)
        {
            GroupControlTag[counter].transform.gameObject.tag = "ThereIsNothing";
            //GroupControlTag[counter].transform.parent = null;
            //Destroy(GroupControlTag[counter]);
        }
        //GameObject MyGroupControl = Instantiate(GroupControl, new Vector3(0, 0, -0.13f), Quaternion.identity);

        //MyGroupControl.transform.parent = transform.root;  // Döndürdükten sonra ve kontrol de edildikten sonra bunu çalıştır.

        //GroupControl = GameObject.Find("ParentHex");

        //foreach (Transform GroupControl in transform)
        //{
        //    GroupControl.parent = null;
        //}

        //GroupControl.transform.parent = null; // Parent'ın Child'larını siliyoruz. 
        //Debug.Log("Parent Serbest Bırakıldı.");

        if (transform.position.y > 0.69)
        {
            if (transform.position.x < 4.26)
            {
                Destroy(GameObject.FindWithTag("Border1"));

                // 0.25 scale'de hexborders'ı konumlandır
                // Border kayması x =  2,131 - 1,83 = 0,301 , y =  2,829 - 3,162691 = -0,333691

                //Debug.Log("click 1"); // oluşması tamam. Şimdi başka yere tıkladığında bunu kaldırmak ve yenisini oluşturmak kaldı.
                GameObject myBorder = GameObject.Instantiate(border, new Vector3(transform.position.x + 0.301f, transform.position.y - 0.333691f, -0.13f), Quaternion.identity);

                FirstHexCoordinate = float.Parse(transform.parent.name, CultureInfo.InvariantCulture.NumberFormat);
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

                SecondHexCoordinatex = FirstHexCoordinatex;
                SecondHexCoordinatey = FirstHexCoordinatey - 1;

                ThirdHexCoordinatex = FirstHexCoordinatex + 1 ;
                ThirdHexCoordinatey = FirstHexCoordinatey - 1;

                if(FirstHexCoordinatex % 2 == 1)
                {
                    ThirdHexCoordinatey = FirstHexCoordinatey;
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
                //GameObject MyGroupControl = Instantiate(GroupControl, new Vector3(0, 0, -0.13f), Quaternion.identity);
                //MyGroupControl.name = "NewParenHex";
                //Debug.Log("NewParentHex oluşturuldu");
                GroupControl.transform.gameObject.tag = "GroupControl";
                GroupControl.transform.position = new Vector3(HexXFloat, HexYFloat, -0.6f);

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
                GameObject.Instantiate(border, new Vector3(transform.position.x - 0.308f, transform.position.y - 0.338051f, -0.13f), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            }
        }
        

        else if (0.36 > transform.position.y & transform.position.y > 0.35)
        {
            Destroy(GameObject.FindWithTag("Border1"));
            GameObject.Instantiate(border, new Vector3(transform.position.x + 0.308f, transform.position.y, -0.13f), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        }

        else
        {
            Destroy(GameObject.FindWithTag("Border1"));
            GameObject.Instantiate(border, new Vector3(transform.position.x + 0.301f, transform.position.y + 0.368719f, -0.13f), Quaternion.identity);
        }    
    }

    private object GetType(string name)
    {
        throw new NotImplementedException();
    }
}
