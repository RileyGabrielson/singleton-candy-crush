using UnityEngine;
using TMPro;

public class Piece : MonoBehaviour
{
  public TextMeshProUGUI text;

  private int value;
  private float timer;
  private float checkTime = 1.0f;
  private float startingX;

  private void Start() {
    this.value = Random.Range(0, 10);
    this.timer = this.checkTime * Random.Range(0f, 1f);
    this.text.SetText(this.value.ToString());
    this.startingX = transform.position.x;
  }

  public void Remove() {
    Score.instance.AddPoints(this.value);
    Object.Destroy(this.gameObject);
  }

  public int GetValue() {
    return this.value;
  }

  public void Teleport(Vector2 newPosition) {
    this.startingX = newPosition.x;
    this.transform.position = newPosition;
  }

  private void Update() {
    this.timer -= Time.deltaTime;
    if(this.timer < 0) {
      this.CheckForMatchingNeighbors();
    }
    this.transform.position = new Vector2(this.startingX, this.transform.position.y);
  }

  private void CheckForMatchingNeighbors() {
    Vector3 position = this.transform.position;

    Vector2 up = new Vector2(position.x, position.y + 1f);
    Vector2 down = new Vector2(position.x, position.y - 1f);
    Vector2 left = new Vector2(position.x - 1f, position.y);
    Vector2 right = new Vector2(position.x + 1f, position.y);

    this.CheckMatchesAtPositions(up, down);
    if(this) this.CheckMatchesAtPositions(left, right);
  }

  private void CheckMatchesAtPositions(Vector2 pos1, Vector2 pos2) {
    Vector3 position = this.transform.position;
    Collider2D hit1 = Physics2D.OverlapCircle(pos1, 0.3f);
    Collider2D hit2 = Physics2D.OverlapCircle(pos2, 0.3f);

    if(hit1 && hit2) {
      Piece piece1 = hit1.GetComponent<Piece>();
      Piece piece2 = hit2.GetComponent<Piece>();

      if(this && piece1 && piece2 && piece1.GetValue() == this.value && piece2.GetValue() == this.value) {
        piece1.Remove();
        piece2.Remove();
        this.Remove();
        return;
      }
    }
  }
}
