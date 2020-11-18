using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class StartCheck : MonoBehaviour
{
    // Bu kod oyunun başlangıcında aynı olan hexagonları patlatıyor, yerlerini dolduruyor ve bunu skora işlemiyor.

    CreateHexagon JustCoordinates;
    private string FirstHex, TravellerHex, FirstColor, SecondColor, ThirdColor, FirstTag;
    GameObject FirstGameObject, SecondGameObject, ThirdGameObject, SecondCoordinate, ThirdCoordinate;
    private int HexCoordinateInt;
    public int skor;
    private int HexCoordinatex, HexCoordinatey, SecondHexCoordinatex, SecondHexCoordinatey, ThirdHexCoordinatex;
    private int ThirdHexCoordinatey, SecondHexX, SecondHexY, ThirdHexX, ThirdHexY;
    private string[] AroundHexs = new string[6];
    float[] UEmptyHexs = new float[3];
    private float HexCoordinate;
    public GameObject[] myObjects;
    private GameObject newGenHex;
    float xOffset = 0.61f;
    float yOffset = 0.70282032302f;
    private string FirstEmpty;
    private string SecondEmpty;
    private string ThirdEmpty;
    private int IsItCount;

    void Start()
    {
        // AreThereAnyLeft'de son if in içine bir sayaç koy. Eğer eşleşme varsa oraya girecek ve sayaç artacaktır. Sayaç sıfırdan
        // büyük olduğu sürece Start()'da döngüye devam ettir. Eğer hiç eşleşen yoksa o if e girmeyecek ve sayaç da artmayacaktır.

        AreThereAnyLeft();
    }


    public void AreThereAnyLeft()
    {
        IsItCount = 0;

        Debug.Log("Is it Count? " + IsItCount);

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                FirstHex = "" + x + "." + y;
                FirstGameObject = GameObject.Find(FirstHex);

                if (x % 2 == 0)
                {
                    AroundHexs[0] = "" + (x + 1) + "." + (y - 1);
                    AroundHexs[1] = "" + (x + 1) + "." + (y);
                    AroundHexs[2] = "" + (x) + "." + (y + 1);
                    AroundHexs[3] = "" + (x - 1) + "." + (y);
                    AroundHexs[4] = "" + (x - 1) + "." + (y - 1);
                    AroundHexs[5] = "" + (x) + "." + (y - 1);

                    for (int a = 0; a < 6; a++)
                    {
                        try
                        {
                            Debug.Log("Başlangıç: " + FirstHex + " Konum: " + AroundHexs[a] + " Renk: " + GameObject.Find(AroundHexs[a]).transform.gameObject.tag);
                        }
                        catch
                        {
                            AroundHexs[a] = "";
                            //Debug.Log(a + "'da Sıkıntı Var. " + " Yeni Değeri: " + AroundHexs[a]);
                            continue;
                        }
                    }
                }

                else
                {
                    AroundHexs[0] = "" + (x + 1) + "." + (y);
                    AroundHexs[1] = "" + (x + 1) + "." + (y + 1);
                    AroundHexs[2] = "" + (x) + "." + (y + 1);
                    AroundHexs[3] = "" + (x - 1) + "." + (y + 1);
                    AroundHexs[4] = "" + (x - 1) + "." + (y);
                    AroundHexs[5] = "" + (x) + "." + (y - 1);

                    for (int a = 0; a < 6; a++)
                    {
                        try
                        {
                            Debug.Log("Başlangıç: " + FirstHex + " Konum: " + AroundHexs[a] + " Renk: " + GameObject.Find(AroundHexs[a]).transform.gameObject.tag);
                        }
                        catch
                        {
                            AroundHexs[a] = "";
                            //Debug.Log(a + "'da Sıkıntı Var. " + " Yeni Değeri: " + AroundHexs[a]);
                            continue;
                        }
                    }
                }

                for (int hexstag = 0; hexstag < AroundHexs.Length; hexstag++)
                {
                    if (!(AroundHexs[hexstag] == ""))
                    {
                        try // Köşelerde Kalan Hex'in etrafında boş kareler olduğu için, eğer yoksa if e gel diyorum.
                        {
                            if (FirstGameObject.tag == GameObject.Find(AroundHexs[hexstag]).transform.gameObject.tag & FirstGameObject.tag == GameObject.Find(AroundHexs[hexstag + 1]).transform.gameObject.tag)
                            {
                                Debug.Log("Eşleşme!" + IsItCount);
                                IsItCount++;

                                {
                                    //FirstGameObject.transform.gameObject.tag = "Player";
                                    //GameObject.Find(AroundHexs[hexstag]).transform.gameObject.tag = "Finish";
                                    //GameObject.Find(AroundHexs[hexstag + 1]).transform.gameObject.tag = "Respawn";

                                    //FirstEmpty = GameObject.FindGameObjectWithTag("Player").name;
                                    //SecondEmpty = GameObject.FindGameObjectWithTag("Finish").name;
                                    //ThirdEmpty = GameObject.FindGameObjectWithTag("Respawn").name;
                                }

                                FirstEmpty = FirstGameObject.name;
                                SecondEmpty = GameObject.Find(AroundHexs[hexstag]).name;
                                ThirdEmpty = GameObject.Find(AroundHexs[hexstag + 1]).name;

                                FirstGameObject.tag = "Respawn";
                                GameObject.Find(AroundHexs[hexstag]).tag = "Finish";
                                GameObject.Find(AroundHexs[hexstag + 1]).tag = "Player";

                                Destroy(FirstGameObject);
                                Destroy(GameObject.Find(AroundHexs[hexstag]));
                                Destroy(GameObject.Find(AroundHexs[hexstag + 1]));

                                EmptyControl(FirstEmpty, SecondEmpty, ThirdEmpty);

                                break;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
        } 

        if (IsItCount > 0)
        {
            Debug.Log("Buraya Geldi 1 " + IsItCount);
            AreThereAnyLeft();
        }
        else
        {
            Debug.Log("Buraya Geldi 2 " + IsItCount);
        }
    }

    public void EmptyControl(string first, string second, string third) // Her seferinde konumu güncellemesi gerekiyor??
    {
        UEmptyHexs[0] = float.Parse(first, CultureInfo.InvariantCulture.NumberFormat); // Stringi Float'a çeviriyoruz
        UEmptyHexs[1] = float.Parse(second, CultureInfo.InvariantCulture.NumberFormat); // Stringi Float'a çeviriyoruz
        UEmptyHexs[2] = float.Parse(third, CultureInfo.InvariantCulture.NumberFormat); // Stringi Float'a çeviriyoruz

        for (int counter = 0; counter < 3; counter++)
        {
            if (UEmptyHexs[counter] < 1) // Eğer noktamızın x'i sıfırlı bir konumdaysa
            {
                HexCoordinatex = 0;
                UEmptyHexs[counter] *= 10;
                HexCoordinatey = (int)UEmptyHexs[counter];
            }

            else
            {
                UEmptyHexs[counter] *= 10;
                HexCoordinateInt = (int)UEmptyHexs[counter];
                HexCoordinatey = (HexCoordinateInt) % 10;
                HexCoordinatex = HexCoordinateInt / 10;
            }

            float yPosition = HexCoordinatey * yOffset;

            if (HexCoordinatex % 2 == 1) // Yataydaki her tek sayı konumundaki hex'i düzgün bir örüntü oluşturmak için yukarı itiyor.
            {
                yPosition += yOffset / 2f;
            }

            GameObject SelectedHexagon = PickHexagon();
            newGenHex = Instantiate(SelectedHexagon, new Vector2(HexCoordinatex * xOffset, yPosition), Quaternion.identity); //Hexagon oluşturuyor.
            newGenHex.name = HexCoordinatex + "." + HexCoordinatey;
        }
        first = null;
        second = null;
        third = null;
    }

    //for (int hexstag = 0; hexstag < AroundHexs.Length; hexstag++)
    //{
    //    try
    //    {
    //        if (FirstGameObject.tag == GameObject.Find(AroundHexs[0]).transform.gameObject.tag && FirstGameObject.tag == GameObject.Find(AroundHexs[1]).transform.gameObject.tag)
    //        {
    //            YesThereIsMore = true;
    //            break;
    //        }
    //        else if (FirstGameObject.tag == GameObject.Find(AroundHexs[1]).transform.gameObject.tag && FirstGameObject.tag == GameObject.Find(AroundHexs[2]).transform.gameObject.tag)
    //        {
    //            YesThereIsMore = true;
    //            break;
    //        }
    //        else if (FirstGameObject.tag == GameObject.Find(AroundHexs[2]).transform.gameObject.tag && FirstGameObject.tag == GameObject.Find(AroundHexs[3]).transform.gameObject.tag)
    //        {
    //            YesThereIsMore = true;
    //            break;
    //        }
    //        else if (FirstGameObject.tag == GameObject.Find(AroundHexs[3]).transform.gameObject.tag && FirstGameObject.tag == GameObject.Find(AroundHexs[4]).transform.gameObject.tag)
    //        {
    //            YesThereIsMore = true;
    //            break;
    //        }
    //        else if (FirstGameObject.tag == GameObject.Find(AroundHexs[4]).transform.gameObject.tag && FirstGameObject.tag == GameObject.Find(AroundHexs[5]).transform.gameObject.tag)
    //        {
    //            YesThereIsMore = true;
    //            break;
    //        }
    //        else if (FirstGameObject.tag == GameObject.Find(AroundHexs[5]).transform.gameObject.tag && FirstGameObject.tag == GameObject.Find(AroundHexs[0]).transform.gameObject.tag)
    //        {
    //            YesThereIsMore = true;
    //            break;
    //        }
    //        else
    //        {
    //            YesThereIsMore = false;
    //            break;

    //        }
    //    }
    //    catch
    //    {
    //        continue;
    //    }

    //}


    public GameObject PickHexagon() // Hexagon renklerinden birini döndürüyor.
    {
        return myObjects[Random.Range(0, myObjects.Length)];
    }
}
