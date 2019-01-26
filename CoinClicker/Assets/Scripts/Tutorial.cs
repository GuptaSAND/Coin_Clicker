using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    public int StatTrack = 1;
    public int QuestButtonStatus = 0;
    public Button QuestButton;
    public Text TutorialText;
    public Canvas TutorialCanvas;
    public string Stat1 = "Welcome to Coin Clicker! Click on the shop button to get started!";
    public string Stat2 = "Here you can view your upgrades! Click on upgrade clicker to continue.";
    public string Stat3 = "Click on the red X in your upper right hand corner to exit the shop.";
    public string Stat4 = "Great job! click the coin in the middle to start earning golden coins!";
    public string Stat5 = "Reach 100 Gold Coins";
    public string Stat6 = "Upgrade Clicker to level 5!";
    public Button TutSaveButton;
    public Button TutLoadButton;
    // Use this for initialization
    public void TutSave()
    {
        PlayerPrefs.SetInt("TutorialStatus", StatTrack);
    }
    void Start () {
		QuestButton.onClick.AddListener(MoveTutorial);
        TutorialText.text = Stat1;
		QuestButtonStatus = 0;
		QuestButton.transform.position = new Vector3(30f,127f,0f);
        TutSaveButton.onClick.AddListener(TutSave);
        TutLoadButton.onClick.AddListener(TutLoad);
    }

    // Update is called once per frame
    void Update()
    {
        switch (StatTrack)
        {
            case 1:
                TutorialText.text = Stat1;
                break;
            case 2:
                TutorialText.text = Stat2;
                break;
            case 3:
                TutorialText.text = Stat3;
                break;
            case 4:
                TutorialText.text = Stat4;
                break;
            case 5:
                TutorialText.text = Stat5;
                break;
            case 6:
                TutorialText.text = Stat6;
                break;
            default:
                TutorialText.text = "";
                break;
        }
    }

    public void TutLoad() 
    {
        StatTrack = PlayerPrefs.GetInt("TutorialStatus");
    }
	public void MoveTutorial()
	{
		if(QuestButtonStatus == 1)
			QuestButtonStatus = 0;
		else
			QuestButtonStatus = 1;
		switch (QuestButtonStatus)	
		{
			case 0:
				while (QuestButton.transform.position.x > 30)
					QuestButton.transform.position = QuestButton.transform.position + new Vector3(-0.001f,0,0);
			break;
			case 1:
				while (QuestButton.transform.position.x < 158)
					QuestButton.transform.position = QuestButton.transform.position + new Vector3(0.001f,0,0);
			break;
		}

	}
    public void TutorialTextUpdate(string source)
    {
		if (StatTrack == 1 && source == "shop")
        {
            StatTrack = StatTrack + 1;
        }
        else
            if (StatTrack == 2 && source == "ButtonUp")
        	{
            	StatTrack = StatTrack + 1;
        	}
        		else
                	if (StatTrack == 3 && source == "CloseShop")
        			{
            			StatTrack = StatTrack + 1;
        			}
        			else
                    	if (StatTrack == 4 && source == "CoinUp")
        				{
            				StatTrack = StatTrack + 1;
        				}
                        else
                            if (StatTrack == 5 && source == "Coin100")
                            {
                                StatTrack = StatTrack + 1;
                            }

    }
    }


