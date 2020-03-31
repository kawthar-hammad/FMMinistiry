using Almotkaml.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.EntityCore.Entities;
using Almotkaml.MFMinistry.Repository;
using System;
using System.Linq;

namespace Almotkaml.MFMinistry.EntityCore.Repositories
{
    public class CompanyInfoRepository : ICompanyInfoRepository
    {
        internal CompanyInfoRepository(MFMinistryDbContext context)
        {
            Context = context;
        }
        private MFMinistryDbContext Context { get; }

        public CompanyInfo Load()
        {
            var domainCompanyInfo = new CompanyInfo();

            foreach (var dbCompanyInfo in Context.Infos.ToList())
            {
                var type = domainCompanyInfo.GetType().GetProperty(dbCompanyInfo.Name).PropertyType;

                var value = Convert.ChangeType(dbCompanyInfo.Value, type);

                domainCompanyInfo.SetValue(dbCompanyInfo.Name, value);
            }
            return domainCompanyInfo;
        }

        public void Save(CompanyInfo companyInfo)
        {
            var dbCompanyInfos = Context.Infos.ToList();

            foreach (var domainCompanyInfoProperty in companyInfo.GetType().GetProperties())
            {
                var dbCompanyInfo = dbCompanyInfos.FirstOrDefault(s => s.Name == domainCompanyInfoProperty.Name);

                var domainValue = domainCompanyInfoProperty.GetValue(companyInfo)?.ToString();

                if (dbCompanyInfo != null)
                    dbCompanyInfo.Value = domainValue;
                else
                    Context.Infos.Add(new Info()
                    {
                        Name = domainCompanyInfoProperty.Name,
                        Value = domainValue
                    });
            }
        }

    }
}