namespace Ji2.Context.Modules.Context
{
    public interface IInstaller<T>
    {
        public T Install(DiContext diContext);
    }
}