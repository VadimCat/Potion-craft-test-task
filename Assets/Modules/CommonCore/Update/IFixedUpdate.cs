namespace Modules.CommonCore
{
    /// <summary>
    /// Interface for objects that require update calls during Unity's FixedUpdate phase.
    /// </summary>
    public interface IFixedUpdate
    {
        void OnFixedUpdate();
    }
}