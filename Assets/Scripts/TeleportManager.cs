using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
  public static TeleportManager instance;

  private void Awake()
  {
      if (instance != null)
      {
          Debug.LogWarning("Multiple TeleportManager Instances");
          Destroy(instance);
      }
      instance = this;
  }

  private List<PieceClickHandler> teleportPieces = new List<PieceClickHandler>();

  public void AddPieceToTeleport(PieceClickHandler piece) {
    teleportPieces.Add(piece);
    if(teleportPieces.Count >= 2) {
      this.Teleport();
    }
  }

  private void Teleport() {
    PieceClickHandler piece1 = this.teleportPieces[0];
    PieceClickHandler piece2 = this.teleportPieces[1];

    if(piece1 && piece2) {
      Vector2 position1 = piece1.transform.position;
      Vector2 position2 = piece2.transform.position;
      piece1.Teleport(position2);
      piece2.Teleport(position1);
    }

    this.teleportPieces.Clear();
  }
}
