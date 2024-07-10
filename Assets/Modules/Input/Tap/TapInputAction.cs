using System;
using Ji2Core.DataTypes;
using Modules.CommonCore;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace Modules.Input.Tap
{
 public class TapInputAction: ITapInputAction, IUpdate, IDisposable
 {
  private readonly TouchScreenInputActions _touchInput;
  private readonly UpdateLoop _updateLoop;

  private readonly ReactiveProperty<TouchData> _tapData = new ();
  public event Action<TouchData> EventTapUpdated
  {
   add => _tapData.EventValueChanged += value;
   remove => _tapData.EventValueChanged -= value;
  }

  public TapInputAction(TouchScreenInputActions touchInput, UpdateLoop updateLoop)
  {
   _touchInput = touchInput;
   _updateLoop = updateLoop;
  }

  public void Enable()
  {
   _touchInput.Enable();
   _updateLoop.Add(this);
  }

  public void OnUpdate()
  {
   if (Mouse.current.leftButton.wasPressedThisFrame)
   {
    UpdateTapData(ClickPhase.Began);
   }
   else if(Mouse.current.leftButton.wasReleasedThisFrame)
   {
    UpdateTapData(ClickPhase.Ended);
   }
   else if (Mouse.current.leftButton.isPressed)
   {
    UpdateTapData(ClickPhase.Pressed);
   }
   else
   {
    UpdateTapData(ClickPhase.NotPressed);
   }
  }

  private void UpdateTapData(ClickPhase phase)
  {
   _tapData.Value = new TouchData(Mouse.current.position.ReadValue(), phase);
  }

  public void Disable()
  {
   _updateLoop.Remove(this);
  }

  public void Dispose()
  {
   _updateLoop.Remove(this);
  }
 }
}