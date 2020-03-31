namespace Almotkaml.MFMinistry.Abstraction
{
    public interface IBackUpRestoreBusiness
    {
        void Prepare();
        bool BackUp(string path);
        bool Restore(string path);
    }
}