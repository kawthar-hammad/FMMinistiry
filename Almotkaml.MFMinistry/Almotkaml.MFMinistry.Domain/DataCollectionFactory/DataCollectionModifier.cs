using System;

namespace Almotkaml.MFMinistry.Domain.DataCollectionFactory
{
    public class DataCollectionModifier
    {
        internal DataCollectionModifier(DataCollection dataCollection)
        {
            DataCollection = dataCollection;
        }
        private DataCollection DataCollection { get; }
        public DataCollectionModifier FirstName(string firstName, string englishFirstName)
        {
            Check.NotEmpty(firstName, nameof(firstName));
            DataCollection.FirstName = firstName;
            //DataCollection.EnglishFirstName = englishFirstName;

            return this;
        }

        public DataCollectionModifier FatherName(string fatherName, string englishFatherName)
        {
            DataCollection.FatherName = fatherName;
            //DataCollection.EnglishFatherName = englishFatherName;

            return this;
        }

        public DataCollectionModifier GrandfatherName(string grandfatherName, string englishGrandfatherName)
        {
            DataCollection.GrandfatherName = grandfatherName;
            //DataCollection.EnglishGrandfatherName = englishGrandfatherName;

            return this;
        }

        public DataCollectionModifier LastName(string lastName, string englishLastName)
        {
            DataCollection.LastName = lastName;
            //DataCollection.EnglishLastName = englishLastName;

            return this;
        }

        public DataCollectionModifier MotherName(string motherName)
        {
            DataCollection.MotherName = motherName;

            return this;
        }

        public DataCollectionModifier Gender(Gender gender)
        {
            DataCollection.Gender = gender;

            return this;
        }

        public DataCollectionModifier BirthDate(DateTime birthDate)
        {
            DataCollection.BirthDate = birthDate;

            return this;
        }

        public DataCollectionModifier BirthPlace(string birthPlace)
        {
            DataCollection.BirthPlace = birthPlace;
            return this;
        }

        public DataCollectionModifier NationalNumber(string nationalNumber)
        {
            DataCollection.NationalNumber = nationalNumber;
            return this;
        }


        public DataCollectionModifier Nationality(int? nationalityId)
        {
            if (nationalityId == 0)
                nationalityId = null;

            DataCollection.NationalityId = nationalityId;
            DataCollection.Nationality = null;
            return this;
        }

        public DataCollectionModifier Nationality(Nationality nationality)
        {
            Check.NotNull(nationality, nameof(nationality));
            DataCollection.NationalityId = nationality.NationalityId;
            DataCollection.Nationality = nationality;
            return this;
        }
        public DataCollectionModifier WifeNationalityId(int? wifeNationalityId)
        {
            if (wifeNationalityId == 0)
                wifeNationalityId = null;

            DataCollection.WifeNationalityId = wifeNationalityId;
            //DataCollection.Nationality = null;
            return this;
        }

        public DataCollectionModifier WifeNationality(Nationality wifeNationality)
        {
            Check.NotNull(wifeNationality, nameof(wifeNationality));
            DataCollection.WifeNationalityId = wifeNationality.NationalityId;
            DataCollection.WifeNationality = wifeNationality;
            return this;
        }

             
        public DataCollectionModifier Address(string address)
        {
            DataCollection.Address = address;
            return this;
        }

        public DataCollectionModifier Phone(string phone)
        {
            DataCollection.Phone = phone;
            return this;
        }

        public DataCollectionModifier SocialStatus(SocialStatus socialStatus)
        {
            DataCollection.SocialStatus = socialStatus;
            return this;
        }

        public DataCollectionModifier ChildernCount(int? childernCount)
        {
            if (childernCount == 0)
                childernCount = null;

            DataCollection.ChildernCount = childernCount;
            return this;
        }

       
     
        public DataCollection Confirm()
        {
            return DataCollection;
        }
    }
}