using Modules.Input.Tap;
using UnityEngine;

namespace Modules.Input
{
 public struct TouchData
 {
  public readonly Vector2 Position;
  public readonly ClickPhase Phase;
  
  public TouchData(Vector2 position, ClickPhase phase)
  {
   Position = position;
   Phase = phase;
  }
 }
}