using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Code credits to CryptoGrounds https://www.youtube.com/watch?v=w_LuLTWXrN8

public class IdleGame : MonoBehaviour
{
    // Declaring our variables.
    public Text moneyText;
    public Text upgrade1Text;
    public Text productionUpgrade1Text;
    public Text moneyPerSecondText;
    public Text customerCountText;
    public double money;
    public double moneyPerSecond;
    private double upgrade1Cost;
    private double productionUpgrade1Cost;
    private double moneyClickValue;
    private double customerCount;
    public int upgrade1Level;
    public int productionUpgrade1Level;

    // Start is called before the first frame update
    public void Start()
    {
        money = 0;
        moneyClickValue = 1;
        upgrade1Cost = 15;
        productionUpgrade1Cost = 25;
        customerCount = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        moneyText.text = "Quarters: " + money.ToString("F0");
        customerCountText.text = "Customers: " + customerCount;
        moneyPerSecond = productionUpgrade1Level;
        moneyPerSecondText.text = moneyPerSecond + " Quarters Per Second";
        upgrade1Text.text = "Click Upgrade 1\nCost: " + upgrade1Cost.ToString("F0") + " Quarters\nPower: +1 Click\nLevel: " + upgrade1Level;
        productionUpgrade1Text.text = "Production Upgrade 1\nCost: " + productionUpgrade1Cost.ToString("F0") + " Quarters\nPower: +1 Quarters/s\nLevel: " + productionUpgrade1Level;

        money += moneyPerSecond * Time.deltaTime;
    }
    
    // Click button to add more money.
    public void AddMoney()
    {
        money += moneyClickValue;
        customerCount += 1;
    }

    // Click button to click the click upgrade 1.
    public void BuyClickUpgrade1()
    {
        if (money >= upgrade1Cost)
        {
            upgrade1Level++;
            money -= upgrade1Cost;
            upgrade1Cost *= 1.08; // 1.07-1.15 is a good change. We can test with different variables.
            moneyClickValue++;
        }
    }

    // Click button to click the production upgrade 1.
    public void BuyProductionUpgrade1()
    {
        if (money >= productionUpgrade1Cost)
        {
            productionUpgrade1Level++;
            money -= productionUpgrade1Cost;
            productionUpgrade1Cost *= 1.08; // 1.07-1.15 is a good change. We can test with different variables.
        }
    }
}