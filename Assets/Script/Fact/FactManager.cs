using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FactManager : MonoBehaviour
{
    public TMP_Text factText;
    private string[] facts = new string[]
    {
        "Fact 1: The fastest goal in football history was scored at 2.8 seconds.",
        "Fact 2: The longest tennis match lasted 11 hours and 5 minutes.",
        "Fact 3: The oldest professional footballer played until the age of 50.",
        "Fact 4: In hockey, the puck can reach speeds of up to 170 km/h.",
        "Fact 5: Croquet was played at the 1900 Olympic Games.",
        "Fact 6: The first basketball game was played with a soccer ball.",
        "Fact 7: The 1984 marathon in Los Angeles ended with a dramatic victory.",
        "Fact 8: The largest stadium in the world can hold more than 114,000 spectators.",
        "Fact 9: In volleyball, the ball can travel at speeds up to 130 km/h.",
        "Fact 10: The longest baseball game lasted 8 hours and 25 minutes.",
        "Fact 11: Table tennis was recognized as an Olympic sport in 1988.",
        "Fact 12: Water polo was originally played in a river.",
        "Fact 13: In the 100-meter sprint, athletes can reach speeds up to 44 km/h.",
        "Fact 14: Golf is the only sport to have been played on the Moon.",
        "Fact 15: In sumo, wrestlers can weigh more than 200 kg."
    };

    void Start()
    {
        ShowRandomFact();
    }

    public void ShowRandomFact()
    {
        int randomIndex = Random.Range(0, facts.Length);
        factText.text = facts[randomIndex];
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}