namespace Modules.CommonCore
{
    /// <summary>
    /// Interface for objects that require update calls during Unity's LateUpdate phase.
    /// </summary>
    public interface ILateUpdate
    {
        void OnLateUpdate();
    }
}