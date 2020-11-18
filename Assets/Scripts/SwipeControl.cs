using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public static bool IsItSwiping;
    public IsItMatch Match;

    void Update() // Seçili noktanın altında üstünde sağında solunda olmasına göre döndürmeyi yap. Saat yönü ve tersine göre yani
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsItSwiping = true;
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            ////swipe upwards
            //if (currentSwipe.y > 0 & (currentSwipe.x > -1f | currentSwipe.x < 1f))
            //{
            //    Debug.Log("up swipe");
            //}

            ////swipe down
            //else if (currentSwipe.y < 0 & (currentSwipe.x > -1f | currentSwipe.x < 1f))
            //{
            //    Debug.Log("down swipe");
            //}
            //swipe left
            try
            {
                GameObject GroupControlTag = GameObject.FindGameObjectWithTag("GroupControl");
                GameObject ChildGameObject1 = GroupControlTag.transform.GetChild(0).gameObject;
                GameObject ChildGameObject2 = GroupControlTag.transform.GetChild(1).gameObject;
                GameObject ChildGameObject3 = GroupControlTag.transform.GetChild(2).gameObject;

                if (currentSwipe.x < 0)
                {
                    // Parent'ı döndürürken Child'ları da ters yöne döndürüyor ki sıraları ve görüntüleri değişmesin.

                    GroupControlTag.transform.Rotate(new Vector3(0, 0, 120));

                    ChildGameObject1.transform.Rotate(new Vector3(0, 0, -120));
                    ChildGameObject2.transform.Rotate(new Vector3(0, 0, -120));
                    ChildGameObject3.transform.Rotate(new Vector3(0, 0, -120));

                    string CarrierOne = ChildGameObject1.name;
                    string CarrierTwo = ChildGameObject2.name;
                    string CarrierThree = ChildGameObject3.name;

                    ChildGameObject1.name = CarrierTwo;
                    ChildGameObject2.name = CarrierThree;
                    ChildGameObject3.name = CarrierOne;

                    ChildGameObject1.transform.parent = null;
                    ChildGameObject2.transform.parent = null;
                    ChildGameObject3.transform.parent = null;

                    Match.MatchExplorer();
                    //Match.EmptyControl();

                    Destroy(GroupControlTag);

                    Debug.Log("left swipe");
                }
                //swipe right

                else if (currentSwipe.x > 0)
                {
                    GroupControlTag.transform.Rotate(new Vector3(0, 0, -120));

                    ChildGameObject1.transform.Rotate(new Vector3(0, 0, 120));
                    ChildGameObject2.transform.Rotate(new Vector3(0, 0, 120));
                    ChildGameObject3.transform.Rotate(new Vector3(0, 0, 120));

                    string CarrierOne = ChildGameObject1.name;
                    string CarrierTwo = ChildGameObject2.name;
                    string CarrierThree = ChildGameObject3.name;

                    ChildGameObject1.name = CarrierThree;
                    ChildGameObject2.name = CarrierOne;
                    ChildGameObject3.name = CarrierTwo;

                    ChildGameObject1.transform.parent = null;
                    ChildGameObject2.transform.parent = null;
                    ChildGameObject3.transform.parent = null;

                    Match.MatchExplorer();
                    //Match.EmptyControl();

                    Destroy(GroupControlTag);

                    Debug.Log("right swipe");
                }
            }
            catch { }


            

        }
        IsItSwiping = false;
    }
}
