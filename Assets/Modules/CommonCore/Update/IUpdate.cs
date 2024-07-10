namespace Modules.CommonCore
{
    /// <summary>
    /// Interface for objects that require update calls during Unity's Update phase.
    /// </summary>
    public interface IUpdate
    {
        void OnUpdate();
    }
}