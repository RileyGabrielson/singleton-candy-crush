using UnityEngine;

public class Board : MonoBehaviour
{
    public Vector2Int start;
    public int width;
    public int height;
    public int newRowHeight;
    public GameObject piecesPrefab;
    public float newRowTime;

    private float timer;

    void Start()
    {
      this.timer = newRowTime;
      this.SpawnPieces();
    }

    void Update() {
      this.timer -= Time.deltaTime;

      if(this.timer < 0) {
        this.SpawnNewRow();
        this.timer = this.newRowTime;
      }
    }

    private void SpawnPieces() 
    {
      for(int i = this.start.x; i < this.start.x + this.width; i++) {
        for(int j = this.start.y; j < this.start.y + this.height; j++) {
          this.SpawnPieceAt(new Vector2Int(i, j));
        }
      }
    }

    private void SpawnPieceAt(Vector2 location) {
      Instantiate(this.piecesPrefab, location, Quaternion.identity, this.transform);
    }

    private void SpawnNewRow() {
      for(int i = this.start.x; i < this.start.x + this.width; i++) {
        this.SpawnPieceAt(new Vector2Int(i, this.newRowHeight));
      }
    }
}
