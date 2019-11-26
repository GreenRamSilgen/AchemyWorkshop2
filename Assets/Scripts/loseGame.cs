using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class LoseGame : MonoBehaviour
{
    public Text message;
    // Use this for initialization
    void Start()
    {
        message.text = decide_ending();
    }


    // Update is called once per frame
    void Update()
    {

    }

    string decide_ending()
    {
        string ending1 = "You have failed to craft the Ultimate potion and failed horribly at financial management.\n" +
           "you are forced out of your workshop because you couldn't pay rent on time \n" +
           "and must leave the town to get away from the debt collector.";

        string ending2 = "You weren't able to pay your workers on time and were beaten by them.\n" +
            "They took every last thing from your workshop and left you with nothing.\n" +
            "To escape from further legal issues you decided to escape from the country and continue to work on alchemy somewhere far away.";

        string ending3 = "Because of your inability to pay rent, you were chased out of your workshop and forced to live in the streets.\n" +
            "Soon, your workers tracked you down and demanded payment for their labors, they chased you down the streets and threw stones at you.\n" +
            "to escape from furthur abuse you decided to leave the city and move back to your home town to become a farmer and milk cows.";

        int ending = Random.Range(1, 4);
        if (ending == 1)
            return ending1;
        else if (ending == 2)
            return ending2;
        else
            return ending3;
    }

}
