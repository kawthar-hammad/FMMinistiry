using System;

namespace Almotkaml.MFMinistry
{
    public interface ISettings
    {
        DateTime Date { get; }
        decimal SickVacation { get; }
        decimal ExtraWork { get; }
        decimal ExtraWorkVacation { get; }
        decimal SolidarityFund { get; }
        decimal EmployeeShareAll { get; }
        decimal EmployeeShareReduced { get; }
        decimal EmployeeShareWithoutReduced { get; }
        decimal EmployeeShareReduced35Year { get; }
        decimal CompanyShareAll { get; }
        decimal CompanyShareReduced { get; }
        decimal SafeShareAll { get; }
        decimal SafeShareReduced { get; }
        decimal CompanyShareWithoutReduced { get; }
        decimal CompanyShareReduced35Year { get; }
        decimal JihadTax { get; }
        decimal ExemptionTaxOne { get; }
        decimal ExemptionTaxTwo { get; }
        decimal IncomeTaxOne { get; }
        decimal IncomeTaxTwo { get; }
        decimal StampTax { get; }
        decimal ChilderPermium { get; }
        bool Saturday { get; }
        bool Sunday { get; }
        bool Monday { get; }
        bool Thursday { get; }
        bool Wednesday { get; }
        bool Tuesday { get; }
        bool Friday { get; }
    }
}