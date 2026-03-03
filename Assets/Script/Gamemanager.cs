using UnityEngine;
using TMPro;
public class Gamemanager : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    private int score;

    public void play()
    {

    }
    public void IncreaseScore()
    {
        score++;
        scoretext.text = score.ToString();
    }

}
