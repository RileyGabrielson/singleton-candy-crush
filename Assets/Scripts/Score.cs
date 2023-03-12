using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
  public static Score instance;

  private void Awake() {
      if (instance != null)
      {
          Debug.LogWarning("Multiple TeleportManager Instances");
          Destroy(instance);
      }
      instance = this;
  }

  public TextMeshProUGUI scoreText;
  private int score = 0;

  public void AddPoints(int points) {
    this.score += points;
    this.scoreText.text = "Score: " + this.score.ToString();
  }

}
