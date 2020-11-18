using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IsItMatch : MonoBehaviour
{
    // Burada istediğim, bir hex'in TouchedOne'a temas eden diğer hexlerin 
    // TouchedThree ve TouchedFive GameObjectlerinin 3'ünün de tag'ının aynı olduğunu nasıl bulurum?

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
    public Text ScoreText;
    float xOffset = 0.61f;
    float yOffset = 0.70282032302f;
    private string FirstEmpty;
    private string SecondEmpty;
    private string ThirdEmpty;

    void Start()
    {
        //skor = PlayerPrefs.GetInt("HexScore");
        //MatchExplorer(); // Her Swipe yapıldıktan sonra kontrol et.
    }

    /*                      Köşelerdeyse 6 tane hex olmaz etrafında
    İlk Hex'in x'i Çiftse = try Çevresindeki (AroundHexs) 1.Hex (+1,-1), 2.Hex (+1,0), 3.Hex (0,+1), 4.Hex (-1,0), 5.Hex (-1,-1), 6.Hex (0,-1) Bunların hepsinin tag'ını bir string listesinde tut.
    İlk Hex'in x'i Tekse  = try Çevresindeki (AroundHexs) 1.Hex (+1,0), 2.Hex (+1,+1), 3.Hex (0,+1), 4.Hex (-1,+1), 5.Hex (-1,0), 6.Hex (0,-1) Bunların hepsinin tag'ını bir string listesinde tut.

            Yok etme şu durumda geçerli; 
                        for(int hexstag = 0; hexstag < AroundHexs.lenght; hexstag++)
                            if(ilkHex.tag == hexstag.hex.tag & ilkHex.tag == hexstag+1.Hex.tag)
                                Destroy ilkHex, hexstag, hexstag+1
    */

    public void MatchExplorer()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                FirstHex = "" + x + "." + y; //ilk durum için 0,0
                FirstGameObject = GameObject.Find(FirstHex); //0.0 objesini atadık.
                //Debug.Log("Başlangıç: " + FirstHex);

                if (x % 2 == 0) {
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
                        try // Köşelerde Kalan Hex'in etrafında boş kareler olduğu için, eğer yoksa if e gir diyorum.
                        {
                            if (FirstGameObject.tag == GameObject.Find(AroundHexs[hexstag]).transform.gameObject.tag & FirstGameObject.tag == GameObject.Find(AroundHexs[hexstag + 1]).transform.gameObject.tag)
                            {
                                skor = PlayerPrefs.GetInt("HexScore");
                                skor += 15;
                                ScoreText.text = "Score: " + skor;
                                PlayerPrefs.SetInt("HexScore", skor);

                                FirstGameObject.transform.gameObject.tag = "Player";
                                GameObject.Find(AroundHexs[hexstag]).transform.gameObject.tag = "Finish";
                                GameObject.Find(AroundHexs[hexstag + 1]).transform.gameObject.tag = "Respawn";

                                FirstEmpty = FirstGameObject.name;
                                SecondEmpty = GameObject.Find(AroundHexs[hexstag]).name;
                                ThirdEmpty = GameObject.Find(AroundHexs[hexstag + 1]).name;

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

        //string[] terms = EmptyHexs.ToArray(); //Listeyi stringe çevirmek için.

        //List<string> UniqueEmptyHexs = EmptyHexs.Distinct().ToList(); Array'i düzene sokmak için list yaptık
        //UEmptyHexs = UniqueEmptyHexs.ToArray(); // Düzene girmiş list i tekrar array yaptık
        //EmptyControl();
    }

    public void EmptyControl(string first, string second, string third)
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
    }

    public GameObject PickHexagon() // Boş kalan yere yeni bir Hex oluşturmak için Hexagon renklerinden birini döndürüyor.
    {
        return myObjects[Random.Range(0, myObjects.Length)];
    }
}