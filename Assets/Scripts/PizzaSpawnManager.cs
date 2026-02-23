using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSpawnManager : MonoBehaviour
{
    [SerializeField] Transform t;
    [SerializeField] GameObject currentPool;
    [SerializeField] string[] tagsName;
    public static PizzaSpawnManager spawnInstance;
    private void Awake()
    {
        spawnInstance = this;
    }
    public int numberOfPizza;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallPizzaInstance()
    {
        numberOfPizza = int.Parse(PizzaUIManager.pizzaUIinstance.pizzanum);
        StartCoroutine(SpawnPizza());
    }

    IEnumerator SpawnPizza()
    {
        //GameObject g = currentPool.;
        /*while(Application.isPlaying)
        {
                yield return new WaitForSeconds(3f);
                GameObject g = currentPool.GetComponent<AdvancedObjectPool>().GetPooledObject(tagsName[0]);
                if (g != null)
                {
                    g.transform.position = new Vector3(t.position.x, t.position.y, t.position.z);
                    g.SetActive(true);
                }
            }
        */
        while (numberOfPizza > 0)
        {
            yield return new WaitForSeconds(1f);
            GameObject g = currentPool.GetComponent<AdvancedObjectPool>().GetPooledObject(tagsName[0]);
            if (g != null)
            {
                g.transform.position = new Vector3(t.position.x, t.position.y, t.position.z);
                g.SetActive(true);
                numberOfPizza--;
            }
            
        }
    }
}
