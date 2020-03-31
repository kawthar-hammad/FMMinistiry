using Almotkaml.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.EntityCore.Entities;
using Almotkaml.MFMinistry.Repository;
using System;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        internal SettingRepository(MFMinistryDbContext context)
        {
            Context = context;
        }
        private MFMinistryDbContext Context { get; }

        public Settings Load()
        {
            var domainSettings = new Settings();

            foreach (var dbSetting in Context.Settings.ToList())
            {
                var type = domainSettings.GetType().GetProperty(dbSetting.Name).PropertyType;

                var value = Convert.ChangeType(dbSetting.Value, type);

                domainSettings.SetValue(dbSetting.Name, value);
            }
            return domainSettings;
        }

        public void Save(Settings settings)
        {
            var dbSettings = Context.Settings.ToList();

            foreach (var domainSettingProperty in settings.GetType().GetProperties())
            {
                var dbSetting = dbSettings.FirstOrDefault(s => s.Name == domainSettingProperty.Name);

                var domainValue = domainSettingProperty.GetValue(settings)?.ToString();

                if (dbSetting != null)
                    dbSetting.Value = domainValue;
                else
                    Context.Settings.Add(new Setting()
                    {
                        Name = domainSettingProperty.Name,
                        Value = domainValue
                    });
            }
        }
    }
}