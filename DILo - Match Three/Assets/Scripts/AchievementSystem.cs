using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class AchievementSystem : Observer
{

    public Image achievementBanner;
    public Text achievementText;

    //Event
    TileEvent cookiesEvent, cakeEvent, gumEvent;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        
        //Buat event
        cookiesEvent = new CookiesTileEvent(3);
        cakeEvent = new CakeTileEvent(10);
        gumEvent = new GumTileEvent(5);

        foreach (var poi in FindObjectsOfType<PointOfInterest>())
        {
            poi.RegisterObserver(this);
        }
    }

    public override void OnNotify(string value)
    {
        string key;
        
        //Seleksi event yang terjadi, dan panggil class event nya
        if(value.Equals("Cookies event"))
        {
            cookiesEvent.OnMatch();
            if (cookiesEvent.AchievementCompleted())
            {
                key = "Match first cookies";
                NotifyAchievement(key, value);
            }
        }

        if (value.Equals("Cake event"))
        {
            cakeEvent.OnMatch();
            if (cakeEvent.AchievementCompleted())
            {
                key = "Match 10 cake";
                NotifyAchievement(key, value);
            }
        }

        if (value.Equals("Gum event"))
        {

            gumEvent.OnMatch();
            if (gumEvent.AchievementCompleted())
            {
                key = "Match 5 gum";
                NotifyAchievement(key, value);
            }
        }          
    }

    void NotifyAchievement(string key, string value)
    {
        //check jika achievement sudah diperoleh
        if (PlayerPrefs.GetInt(value) == 1)
            return;

        PlayerPrefs.SetInt(value, 1);
        achievementText.text = key + " Unlocked !";
        
        //pop up notifikasi
        StartCoroutine(ShowAchievementBanner());
    }

    void ActivateAchievementBanner(bool active)
    {
        achievementBanner.gameObject.SetActive(active);
    }

    IEnumerator ShowAchievementBanner()
    {
        ActivateAchievementBanner(true);
        yield return new WaitForSeconds(2f);
        ActivateAchievementBanner(false);
    }
}