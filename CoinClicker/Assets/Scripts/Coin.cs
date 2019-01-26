using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float numCoins = 0;
    public float coinsOffset = 0;
    public float CoinPrice = 10;
    public float autoclickcoinvalue = 1;
    public int autoclickcoin = 30;
    public int ticker = 0;
    public float autoclickvalueprice = 100;
    public float autoclickspeedprice = 100;
    public int autoclickSpeedMax = 0;
    public int autoclickerenabled = 0;
    public Text coinDisplay;
    public Text upgradePrice; 
    public Text autoclickvaluereturn;
    public Text autoclickspeedreturn;
    public Text autoclickPriceTxt;
    public Text autoclickSpeedTxt;
    public Text UnlockAutoClickPrice;
    public Button SaveButton;
	public Button LoadButton;
    public Button autoclickvalueButton;
    public Button autoclickspeed;
    public Button unlockAutoclicker;
    public GameObject BarfCoin;
    public Tutorial Tutorial;
    public Canvas AutoclickerEN;
    public Canvas AutoclickerDIS;

    // Use this for initialization
    void Start()
    {
        autoclickcoin = 30;
        numCoins = CoinPrice;
		SaveButton.onClick.AddListener(linkSave);
		LoadButton.onClick.AddListener(linkLoad);
        autoclickvalueButton.onClick.AddListener(AutoClickValueUP);
        autoclickspeed.onClick.AddListener(AutoClickSpeed);
        unlockAutoclicker.onClick.AddListener(UnlockAutoClick);
        UnlockAutoClickPrice.text = "Price: 150 Coins";
        AutoclickerEN.enabled = false;
        AutoclickerDIS.enabled = true;
    }

    public void UnlockAutoClick() 
    {
        if (numCoins >= 150)
        {
            AutoclickerEN.enabled = true;
            AutoclickerDIS.enabled = false;
            numCoins = numCoins - 150;
            autoclickerenabled = 1;
        }

}

    public void AutoClickValueUP()
    {
        if (numCoins >= autoclickvalueprice)
        {
            numCoins = numCoins - autoclickvalueprice;
            autoclickcoinvalue = autoclickcoinvalue * 1.5f + 1;
            autoclickvalueprice = autoclickvalueprice * 1.5f;
            autoclickvaluereturn.text = "Success";
        }
        else
        {
            autoclickvaluereturn.text = "failed";
        }
    }
    public void AutoClickSpeed()
    {
        if (numCoins >= autoclickspeedprice)
        {
            if (autoclickSpeedMax == 0)
            {
                numCoins = numCoins - autoclickspeedprice;
                autoclickcoin = autoclickcoin - 1;
                autoclickspeedprice = (int)((float)autoclickspeedprice * 1.5);
                autoclickspeedreturn.text = "Success";
                if (autoclickcoin == 0)
                {
                    autoclickSpeedMax = 1;
                    autoclickspeedreturn.text = "Maxed Out";
                }
            }
        }
        else
        {
            autoclickspeedreturn.text = "failed";
        }
    }

    public void linkSave()
	{
        PlayerPrefs.SetFloat("numCoins",numCoins);
        PlayerPrefs.SetFloat("Upgrade1Price", CoinPrice);
        PlayerPrefs.SetFloat("CoinPClick", coinsOffset);
        PlayerPrefs.SetFloat("ACCV", autoclickcoinvalue);
        PlayerPrefs.SetInt("ACCC", autoclickcoin);
        PlayerPrefs.SetInt("Ticker", ticker);
        PlayerPrefs.SetFloat("ACVP", autoclickvalueprice);
        PlayerPrefs.SetFloat("ACSP", autoclickspeedprice);
        PlayerPrefs.SetInt("ACSM", autoclickSpeedMax);
        PlayerPrefs.SetInt("Enabled", autoclickerenabled);
        PlayerPrefs.SetInt("StatT", Tutorial.StatTrack);
        PlayerPrefs.SetString("Stat1", Tutorial.Stat1);
        PlayerPrefs.SetString("Stat2", Tutorial.Stat2);
        PlayerPrefs.SetString("Stat3", Tutorial.Stat3);
        PlayerPrefs.SetString("Stat4", Tutorial.Stat4);
        PlayerPrefs.SetString("Stat5", Tutorial.Stat5);
        PlayerPrefs.SetInt("QBS", Tutorial.QuestButtonStatus);
        Debug.Log(numCoins + "," + CoinPrice + "," + coinsOffset + "," + autoclickcoin);
    }
	public void linkLoad()
	{
        numCoins = PlayerPrefs.GetFloat("numCoins");
        CoinPrice = PlayerPrefs.GetFloat("Upgrade1Price");
        coinsOffset = PlayerPrefs.GetFloat("CoinPClick");
        autoclickcoin = PlayerPrefs.GetInt("ACCC");
        autoclickcoinvalue = PlayerPrefs.GetFloat("ACCV");
        ticker = PlayerPrefs.GetInt("Ticker");
        autoclickvalueprice = PlayerPrefs.GetFloat("ACVP");
        autoclickspeedprice = PlayerPrefs.GetFloat("ACSP");
        autoclickSpeedMax = PlayerPrefs.GetInt("ACSM");
        autoclickerenabled = PlayerPrefs.GetInt("Enabled");
        Tutorial.StatTrack = PlayerPrefs.GetInt("StatT");
        Tutorial.Stat1 = PlayerPrefs.GetString("Stat1");
        Tutorial.Stat2 = PlayerPrefs.GetString("Stat2");
        Tutorial.Stat3 = PlayerPrefs.GetString("Stat3");
        Tutorial.Stat4 = PlayerPrefs.GetString("Stat4");
        Tutorial.Stat5 = PlayerPrefs.GetString("Stat5");
        Tutorial.QuestButtonStatus = PlayerPrefs.GetInt("QBS");
        Debug.Log(numCoins + "," + CoinPrice + "," + coinsOffset + "," + autoclickcoin);

    }
    // Update is called once per frame
    void Update()
    {
        if (autoclickerenabled == 1)
        {
            if (ticker > autoclickcoin)
            {
                ticker = autoclickcoin - 1;
            }
            if (autoclickcoin > 30)
            {
                Debug.Log("ELEVEN OR MORE AUTOCLICKER");
            }
            else
            {
                if (ticker == autoclickcoin)
                {
                    ticker = 0;
                    numCoins = numCoins + autoclickcoinvalue;
                }
                else
                {
                    ticker = ticker + 1;
                }
            }
        }
        coinDisplay.text = "You Have: " + Mathf.Round(numCoins).ToString() + " Golden coins!";
        upgradePrice.text = "Cost: " + Mathf.Round(CoinPrice).ToString() +" Golden Coins";
        autoclickPriceTxt.text = "Cost: " + Mathf.Round(autoclickvalueprice) + " Golden Coins";
        autoclickSpeedTxt.text = "Cost: " + Mathf.Round(autoclickspeedprice) + " Golden Coins";

    }

    void OnMouseDown()
    {
        numCoins = numCoins + coinsOffset;
        Tutorial.TutorialTextUpdate("CoinUp");
        if (numCoins <= 100)
        {
            Tutorial.TutorialTextUpdate("Coin100");
        }
        if (CoinPrice <= 10)
        {
            Debug.Log("HI WORLD");
        }
        else 
        {
            Instantiate(BarfCoin);
        }
        numCoins = Mathf.Round(numCoins);
    }

    public bool AttemptUpgrade()
    {
        if (numCoins >= CoinPrice)
        {
            coinsOffset = coinsOffset + 5;
            numCoins = numCoins - CoinPrice;
            CoinPrice = CoinPrice * 0.5f + CoinPrice;
            return true;
        }
        return false;
    }
}