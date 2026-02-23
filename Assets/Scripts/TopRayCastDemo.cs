using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRayCastDemo : MonoBehaviour
{
    public  string topingsSelectd;
    // Start is called before the first frame update
    void Start()
    {



    }



    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        bool isRaycast = Physics.Raycast(ray, out RaycastHit hit, 4f);

        topingsSelectd = PizzaUIManager.pizzaUIinstance.pizzaSelected;

        if (isRaycast)
        {
            if(transform.parent.name == "DoughStage")
            {
                hit.collider.transform.GetChild(0).gameObject.SetActive(false);
                hit.collider.transform.GetChild(1).gameObject.SetActive(true);

            }

            else if (transform.parent.name == "BaseStage")
            {
                hit.collider.transform.GetChild(1).gameObject.SetActive(false);
                hit.collider.transform.GetChild(2).gameObject.SetActive(true);

            }

            else if(transform.parent.name == "ToppingStage")
            {
                if (hit.collider)
                {
                    ToppingsInp(topingsSelectd, hit);
                }
            }

            else if(transform.parent.name == "PackagingStage")
            {
                for(int i =0; i < hit.collider.transform.childCount; i++)
                {
                    hit.collider.transform.GetChild(i).gameObject.SetActive(false);
                }
                hit.collider.transform.GetChild(6).gameObject.SetActive(true);
            }

            else if (transform.parent.name == "BrandingStage")
            {
                hit.collider.transform.GetChild(6).gameObject.SetActive(false);
                hit.collider.transform.GetChild(7).gameObject.SetActive(true);

            }
        }

    }

    void ToppingsInp( string topingName, RaycastHit hit)
    {
        if(topingName.Contains("MushRoom"))
        {
            hit.collider.transform.GetChild(3).gameObject.SetActive(true);
        }

        if (topingName.Contains("PepperOni"))
        {
            hit.collider.transform.GetChild(4).gameObject.SetActive(true);
        }
        if (topingName.Contains("PineApple"))
        {
            hit.collider.transform.GetChild(5).gameObject.SetActive(true);
        }
    }
}
