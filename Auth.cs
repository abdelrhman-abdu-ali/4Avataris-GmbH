using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
public class Auth : MonoBehaviour
{
    public Text debugText;
    public InputField leaderboard;
    // Start is called before the first frame update
    void Start()
    {

        intialize();
    }

    // Update is called once per frame
    void intialize()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .RequestServerAuthCode(false)
        .Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        debugText.text = "playgames initialized";
        SignIN();
    }
    void SignIN()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (success) =>

         {
             switch (success)
             {
                 case SignInStatus.Success:
                     debugText.text = "signedIN";
                     break;

                 default:
                     debugText.text = "not successfull"; 
                     break;
             }


         });


    }
    public void post()
    {
        Social.ReportScore(int.Parse(leaderboard.text), "CgkIzNbMmNsfEAIQAw", (bool success) =>
        {
            if(success)
            {
                debugText.text = "leaderWork";

            }
            else
            {
                debugText.text = "leaderNOTWORKING";
            }
        });
    }
   public void show()
    {
        Social.ShowAchievementsUI();
    }
}
