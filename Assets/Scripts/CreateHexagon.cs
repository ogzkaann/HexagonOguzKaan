using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHexagon : MonoBehaviour
{
    public GameObject[] myObjects;
    public int width = 8, height = 9;
    float newHexX, newHexY; // Oyuncuya grid size değiştirmek için editörden seçenek sunulur.
    GameObject newHex;

    // 3'lünün orta noktası x = 0.20333333333, y = 0.35141016666

    float xOffset = 0.61f; // Matematiksel hesap sonucu aynı yataydaki hex'in olması gereken konum
    float yOffset = 0.70282032302f; // Matematiksel hesap sonucu üstteki hex'in olması gereken konum

    public void CreateHexagons()
    {
        for (int x = 0; x < width; x++) // Oyuncu editör üzerinden grid size değiştirebilir.
        {
            for (int y = 0; y < height; y++)
            {
                float yPosition = y * yOffset; // Düşeydeki hexleri 1 aralıkla değil de offset aralığı kadar ittiriyor

                if (x % 2 == 1) // Yataydaki her tek sayı konumundaki hex'i düzgün bir örüntü oluşturmak için yukarı itiyor.
                {
                    yPosition += yOffset/2f;
                }
                GameObject SelectedHexagon = PickHexagon();
                newHex = Instantiate(SelectedHexagon, new Vector2(x * xOffset, yPosition), Quaternion.identity); //Hexagon oluşturuyor.
                newHex.name = x + "." + y; // Hierarchy'de okunabilirliği arttırmak için yeniden isimlendirdim.
                //Hexagon hexagon = newHex.GetComponent<Hexagon>(); 
                //hexagon.selected = SelectedHexagon.name;
            }
        }
    }

    public GameObject PickHexagon() // Hexagon renklerinden birini döndürüyor.
    {
        return myObjects[Random.Range(0, myObjects.Length)];
    }
}
