using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PizzaUIManager : MonoBehaviour
{
    [SerializeField] GameObject productionPanel;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject TopMenuPanel;
    [SerializeField] TMP_InputField noOfPizza;
    [SerializeField] TMP_Dropdown topingsmenu;
    public string pizzanum;
    public static PizzaUIManager pizzaUIinstance;
    public string pizzaSelected;

    private void Awake()
    {
        pizzaUIinstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputForNumPizzas();
        SelectTopings();
       
    }

    public void StartButton()
    {
        GamePanel.SetActive(false);
        productionPanel.SetActive(true);
        TopMenuPanel.SetActive(true);
    }

    public void SubmitButton()
    {
        
        PizzaSpawnManager.spawnInstance.CallPizzaInstance();
        //productionPanel.SetActive(false);
        TopMenuPanel.SetActive(true);
    }


    void InputForNumPizzas()
    {
        pizzanum = noOfPizza.text;
        //PizzaSpawnManager.spawnInstance.numberOfPizza = pizzanum;
    }

    void SelectTopings()
    {
        topingsmenu.onValueChanged.AddListener(TopingsvalueChange);
    }

    void  TopingsvalueChange( int index)
    {
        string currenttopings = topingsmenu.options[index].text;
        pizzaSelected = currenttopings;
    }
}
