using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using System;

public class PlayGamesScript : MonoBehaviour
{
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();       
		PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
  
        PlayGamesPlatform.Instance.Authenticate(loginCallback, true);
    }

		public void ShowAchievementCall(Boolean success){
		if(success){
				Social.ShowAchievementsUI();
		}
	}

    public void LoginToPlayGames()
	{
			PlayGamesPlatform.Instance.Authenticate(loginCallback,false);
	}

    public void loginCallback(Boolean success){
        if (success)
		{
            FirstAd();
 		}
		else
		{
			Debug.Log("Sign in error");
		}
    }
	public void FirstAd(){
		Social.ReportProgress("CgkIrL_kl_cPEAIQAA", 100.0f, (bool success) => {
			if(success){
				Debug.Log("sucess");
			}
		});
	}
	public void ShowAcheivments(){
		if (PlayGamesPlatform.Instance.localUser.authenticated)
		{
				Social.ShowAchievementsUI();
		}
		else
		{
			PlayGamesPlatform.Instance.Authenticate(ShowAchievementCall,false);
		}
	}

}
