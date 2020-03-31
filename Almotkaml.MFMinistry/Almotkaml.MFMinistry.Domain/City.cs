﻿using Almotkaml;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Almotkaml.MFMinistry.Domain
{
    public class City
    {

        public static City New(string name, int countryId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(countryId, nameof(countryId));


            var city = new City()
            {
                Name = name,
                CountryId = countryId,
            };


            return city;
        }
        public static City New(string name, Country country)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(country, nameof(country));


            var city = new City()
            {
                Name = name,
                Country = country
            };


            return city;
        }
        private City()
        {

        }
        public int CityId { get; private set; }
        public string Name { get; private set; }
        public Country Country { get; private set; }
        public int CountryId { get; private set; }
       
        public void Modify(string name, int countryId)
        {
            Check.NotEmpty(name, nameof(name));
            Check.MoreThanZero(countryId, nameof(countryId));

            Name = name;
            CountryId = countryId;
            Country = null;

        }

        public void Modify(string name, Country country)
        {
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(country, nameof(country));

            Name = name;
            Country = country;

        }

    }
}