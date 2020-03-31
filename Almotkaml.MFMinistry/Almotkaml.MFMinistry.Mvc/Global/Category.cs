using Almotkaml.Extensions;
using Almotkaml.MFMinistry.Mvc.Controllers;
using Almotkaml.MFMinistry.Mvc.Library;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using System.Web.Mvc;

namespace Almotkaml.MFMinistry.Mvc.Global
{
    public class BaseCategory
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public ICollection<Categry> Categories { get; } = new HashSet<Categry>();
    }

    public class Categry
    {
        private string _controllerName;
        private string _actionName;

        public string ControllerName
        {
            get { return _controllerName; }
            set { _controllerName = value.Replace("Controller", ""); }
        }
        public string ActoinName
        {
            get { return _actionName; }
            set { _actionName = value.Replace("Action", ""); }
        }

        public string Title { get; set; }
        public string Icon { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<string> AddedPermissions { get; } = new HashSet<string>();
    }

    public class AllTrue
    {
        public AllTrue()
        {
            _areTrue = true;
        }
        private bool _areTrue;

        public bool AreTrue
        {
            get { return _areTrue; }
            set
            {
                if (_areTrue)
                    _areTrue = value;
            }
        }
    }

    public class Category
    {
        private ICollection<BaseCategory> Categories { get; set; }

        public static string GetPermissionPhrase(string name, Permission permission)
        {
            var secondName = name.Contains("_") ? name.Split('_')[1] : name;

            switch (secondName)
            {
                case "Create":
                    return "إضافة";
                case "Edit":
                    return "تعديل";
                case "Delete":
                    return "حذف";
            }

            var resxName = permission.GetAttribute<DisplayAttribute>(name)?.Name;

            return resxName != null
                ? new ResourceManager(typeof(Resources.Title)).GetString(resxName)
                : secondName;
        }

        public ICollection<BaseCategory> GetCategories(HtmlHelper htmlHelper)
        {
            if (Categories != null)
                return Categories;

            var permissions = htmlHelper.GetPermissions();

            if (permissions == null)
                throw new Exception("No permissions loaded");

            var settings = htmlHelper.GetSettings();

            if (settings == null)
                throw new Exception("No settings loaded");

            Categories = new HashSet<BaseCategory>()
            {
                #region الإعدادات العامة
            
                    new BaseCategory()
                    {
                        Title = "الإعدادات العامة",
                        Icon = "cogs",
                       Categories =
                        {
                            new Categry()
                            {
                                Title = "إعدادات المنظومة",
                                ControllerName = nameof(SettingController),
                                ActoinName=nameof(SettingController.Index ),
                                Icon = "cog",
                                IsVisible = permissions.Setting,
                            },
                            new Categry()
                            {
                                Title = "بيانات الجهة",
                                ControllerName = nameof(CompanyInfoController),
                                ActoinName=nameof(CompanyInfoController.Index ),
                                Icon = "info",
                                IsVisible = permissions.CompanyInfo,
                            },
                            new Categry()
                            {
                                Title = "صلاحيات المستخدمين",
                                ControllerName = nameof(UserGroupController),
                                ActoinName=nameof(UserGroupController.Index ),
                                Icon = "users",
                                IsVisible = permissions.UserGroup,
                            },
                            new Categry()
                            {
                                Title = "إدارة المستخدمين",
                                ControllerName = nameof(UserController),
                                ActoinName=nameof(UserController.Index ),
                                Icon = "user",
                                IsVisible = permissions.User,
                            },
                            new Categry()
                            {
                                Title = "مراقبة المستخدمين",
                                ControllerName = nameof(UserActivityController),
                                ActoinName=nameof(UserActivityController.Index ),
                                Icon = "eye",
                                IsVisible = permissions.UserActivity,
                            },
                            new Categry()
                            {
                                Title = "النسخ الاحتياطي",
                                ControllerName = nameof(BackUpRestoreController),
                                ActoinName=nameof(BackUpRestoreController.Index ),
                                Icon = "database",
                                IsVisible = permissions.BackUp || permissions.Restore,
                                AddedPermissions = {nameof(permissions.BackUp), nameof(permissions.Restore)}
                            },
                        },
                    },
                    #endregion
                #region الإعدادات الأساسية
                
                    new BaseCategory()
                    {
                        Title = "الإعدادات الأساسية",
                        Icon = "wrench",
                        Categories =
                        {
                                new Categry()
                            {
                                Title = "الجنسيات",
                                ControllerName = nameof(NationalityController),
                                ActoinName=nameof(NationalityController.Index ),
                                Icon = "address-card",
                                IsVisible = permissions.Nationality,
                            },
                            new Categry()
                            {
                                Title = "البلدان",
                                ControllerName = nameof(CountryController),
                                ActoinName=nameof(CountryController.Index ),
                                Icon = "globe",
                                IsVisible = permissions.Country,
                            },
                            new Categry()
                            {
                                Title = "المدن",
                                ControllerName = nameof(CityController),
                                ActoinName=nameof(CityController.Index ),
                                Icon = "fas fa-map-marker-alt",
                                IsVisible = permissions.City,
                            },
                            new Categry()
                            {
                                Title = "الفرع البلدي",
                                ControllerName = nameof(BranchController),
                                ActoinName=nameof(BranchController.Index ),
                                Icon = "object-group",
                                IsVisible = permissions.Branch,
                            },
                               new Categry()
                            {
                                Title = "المكاتب",
                                ControllerName = nameof(DepartmentController),
                                ActoinName=nameof(DepartmentController.Index ),
                                Icon = "object-group",
                                IsVisible = permissions.Department,
                            },
                                new Categry()
                            {
                                Title = "الأدراج",
                                ControllerName = nameof(DrawerController),
                                ActoinName=nameof(DrawerController.Index ),
                                Icon = "object-group",
                                IsVisible = permissions.Department,
                            },
                                  new Categry()
                            {
                                Title = "الفئات المستفيدة",
                                ControllerName = nameof(RecipientGroupController),
                                ActoinName=nameof(RecipientGroupController.Index ),
                                Icon = "object-group",
                                IsVisible = permissions.RecipientGroup,
                            },
                             new Categry()
                            {
                                Title = "قوانين الإستفادة",
                                ControllerName = nameof(GrantRuleController),
                                ActoinName=nameof(GrantRuleController.Index ),
                                Icon = "address-card",
                                IsVisible = permissions.GrantRule,
                            },
                               new Categry()
                            {
                                Title = "إدارة معلومات الشهداء",
                                ControllerName = nameof(QuestionController),
                                ActoinName=nameof(QuestionController.Index ),
                                Icon = "object-group",
                                IsVisible = permissions.Question,
                            },
                        },
                    },
                #endregion
                #region إعدادات الهيكلية التنظيمية
                
                    //new BaseCategory()
                    //{
                    //    Title = "إعدادات الهيكلية التنظيمية",
                    //    Icon = "puzzle-piece",
                    //    Categories =
                    //    {
                           
                    //    },
                    //},
                    #endregion
                #region إعدادات البيانات المالية
                
                new BaseCategory()
                {
                    Title = "إعدادات البيانات المالية",
                    Icon = "mdi-domain",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "المصارف",
                            ControllerName = nameof(BankController),
                            ActoinName=nameof(BankController.Index ),
                            Icon = "university",
                            IsVisible = permissions.Bank,
                        },
                        new Categry()
                        {
                            Title = "فروع المصارف",
                            ControllerName = nameof(BankBranchController),
                            ActoinName=nameof(BankBranchController.Index ),
                            Icon = "share-alt-square",
                            IsVisible = permissions.BankBranch,
                        },
                         new Categry()
                        {
                            Title = "المجموعات المالية",
                            ControllerName = nameof(FinancialGroupController),
                            ActoinName=nameof(FinancialGroupController.Index ),
                            Icon = "university",
                            IsVisible = permissions.FinancialGroup,
                        },
                    },
                },
                #endregion
                #region شؤون الشهداء
                
                new BaseCategory()
                {
                    Title = "شؤون الشهداء",
                    Icon = "mdi-domain",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "المذكرات",
                            ControllerName = nameof(MartyrFormController),
                            ActoinName=nameof(MartyrFormController.Index ),
                            Icon = "university",
                            IsVisible = permissions.Bank,
                        },
                    },
                },
                #endregion
                #region شؤون المفقودين
                
                new BaseCategory()
                {
                    Title = "شؤون المفقودين",
                    Icon = "mdi-domain",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "المذكرات",
                            ControllerName = nameof(MissingFormController),
                            ActoinName=nameof(MissingFormController.Index ),
                            Icon = "university",
                            IsVisible = permissions.Bank,
                        },
                    },
                },
                #endregion
                #region شؤون المبتورين
                
                new BaseCategory()
                {
                    Title = "شؤون المبتورين",
                    Icon = "mdi-domain",
                    Categories =
                    {
                        new Categry()
                        {
                            Title = "المذكرات",
                            ControllerName = nameof(BankController),
                            ActoinName=nameof(BankController.Index ),
                            Icon = "university",
                            IsVisible = permissions.Bank,
                        },
                    },
                },
                #endregion
                #region العمليات
                new BaseCategory()
                {
                    Title = "العمليات",
                    Icon = "recycle",
                    Categories =
                    {
                       
                    },
                },
                #endregion
           
                #region التقارير
                
                new BaseCategory()
                {
                    Title = "التقارير",
                    Icon = "file-text-o",
                    Categories =
                    {
                    },
                },
                #endregion
            };

            return Categories;
        }
    }
}