using UnityEngine;
using System.Collections.Generic;

public class PieceClickHandler : MonoBehaviour
{
  public Piece piece;
  public SpriteRenderer sprite;
  public Color selectColor;
  public List<Color> defaultColors;

  private void Start() {
    this.sprite.color = defaultColors[this.piece.GetValue()];
  }

  void OnMouseDown() {
    this.sprite.color = selectColor;
    TeleportManager.instance.AddPieceToTeleport(this);
  }

  public void Teleport(Vector2 position) {
    this.piece.Teleport(position);
    this.sprite.color = defaultColors[this.piece.GetValue()];
  }
}
