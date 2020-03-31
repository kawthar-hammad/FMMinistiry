using Almotkaml.MFMinistry.Abstraction;
using Almotkaml.MFMinistry.Business.Extensions;
using Almotkaml.MFMinistry.Domain;
using Almotkaml.MFMinistry.Models;

namespace Almotkaml.MFMinistry.Business.App_Business.MainSettings
{
    public class CityBusiness : Business, ICityBusiness
    {
        public CityBusiness(HrMFMinistry mfMinistry)
            : base(mfMinistry)
        {
        }

        private bool HavePermission(bool permission = true)
            => ApplicationUser.Permissions.City && permission;




        public CityModel Prepare()
        {
            //if (!HavePermission(ApplicationUser.Permissions.City_Create))
            //    return Null<CityModel>(RequestState.NoPermission);

            return new CityModel()
            {
                CanCreate = ApplicationUser.Permissions.City_Create,
                CanEdit = ApplicationUser.Permissions.City_Edit,
                CanDelete = ApplicationUser.Permissions.City_Delete,
                CountryList = UnitOfWork.Countries.GetAll().ToList(),
                CityGrid = UnitOfWork.Cities
                    .GetCityWithCountry().ToGrid()

            };
        }

        public void Refresh(CityModel model)
        {

        }

        public bool Select(CityModel model)
        {
            //if (!HavePermission(ApplicationUser.Permissions.City_Edit))
            //    return Fail(RequestState.NoPermission);
            if (model.CityId <= 0)
                return Fail(RequestState.BadRequest);

            var city = UnitOfWork.Cities.Find(model.CityId);

            if (city == null)
                return Fail(RequestState.NotFound);
            model.CountryId = city.CountryId;
            model.Name = city.Name;
            return true;
        }

        public bool Create(CityModel model)
        {

            //if (!HavePermission(ApplicationUser.Permissions.City_Create))
            //    return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            if (UnitOfWork.Cities.CityExisted(model.Name, model.CountryId, model.CityId))
                return NameExisted();

            var city = City.New(model.Name, model.CountryId);
            UnitOfWork.Cities.Add(city);

            UnitOfWork.Complete(n => n.City_Create);
            UnitOfWork.Complete(n => n.City_Create,"قام يإضافة "+ model.Name);

            return SuccessCreate();
        }

        public bool Edit(CityModel model)
        {
            if (model.CityId <= 0)
                return Fail(RequestState.BadRequest);

            //if (!HavePermission(ApplicationUser.Permissions.City_Edit))
            //    return Fail(RequestState.NoPermission);

            if (!ModelState.IsValid(model))
                return false;

            var city = UnitOfWork.Cities.Find(model.CityId);
            var cityName = city.Name;
            if (city == null)
                return Fail(RequestState.NotFound);

            if (UnitOfWork.Cities.CityExisted(model.Name, model.CountryId, model.CityId))
                return NameExisted();
            city.Modify(model.Name, model.CountryId);

            //UnitOfWork.Complete(n => n.City_Edit);
            UnitOfWork.Complete(n => n.City_Edit, " قام بالتعديل من " + cityName + " إلى " + model.Name);
            return SuccessEdit();
        }

        public bool Delete(CityModel model)
        {
            //if (!HavePermission(ApplicationUser.Permissions.City_Delete))
            //    return Fail(RequestState.NoPermission);

            if (model.CityId <= 0)
                return Fail(RequestState.BadRequest);

            var city = UnitOfWork.Cities.Find(model.CityId);

            if (city == null)
                return Fail(RequestState.NotFound);

            UnitOfWork.Cities.Remove(city);

            //if (!UnitOfWork.TryComplete(n => n.City_Delete))
            //    return Fail(UnitOfWork.Message);
           
            if (!UnitOfWork.TryComplete(n => n.City_Create, "قام يحذف " + city.Name))
                return Fail(UnitOfWork.Message);

            return SuccessDelete();
        }
    }
}