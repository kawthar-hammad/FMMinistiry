using Almotkaml.MFMinistry.Domain;

namespace Almotkaml.MFMinistry.Repository
{
    public interface ISettingRepository
    {
        Settings Load();
        void Save(Settings settings);
    }
}