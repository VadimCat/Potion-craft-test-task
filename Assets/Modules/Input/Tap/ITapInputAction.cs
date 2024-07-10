using System;

namespace Modules.Input.Tap
{
    public interface ITapInputAction
    {
        event Action<TouchData> EventTapUpdated;
        public void Enable();
        public void Disable();
    }
}