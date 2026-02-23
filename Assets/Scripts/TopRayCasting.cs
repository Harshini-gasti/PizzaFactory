using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRayCasting : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 4f, Color.red);

        bool isRaycast = Physics.Raycast(ray, out RaycastHit hit, 4f);

        if (isRaycast)
        {
            if (Time.time - time >= 2)
            {
                time = Time.time;
                Debug.Log(hit.collider.name);
                Transform[] activeChildren = hit.collider.GetComponentsInChildren<Transform>(false);
                // will not disable pizzaBase
                if (activeChildren[1].name != "PizzaBase")
                {
                    activeChildren[1].gameObject.SetActive(false);
                }
                // will work when toppings is active
                if (activeChildren.Length > 2)
                {
                    activeChildren[1].gameObject.SetActive(false); // disable pizzabase
                    activeChildren[2].gameObject.SetActive(false); // disable toppings
                    hit.collider.transform.GetChild(activeChildren[2].GetSiblingIndex() + 1).gameObject.SetActive(true);
                }
                // will not work when toppings is active
                else
                {
                    hit.collider.transform.GetChild(activeChildren[1].GetSiblingIndex() + 1).gameObject.SetActive(true);
                    if (hit.collider.transform.GetChild(activeChildren[1].GetSiblingIndex() + 1).gameObject.name == "Toppings")
                    {

                    }
                }
            }
        }

    }
}