﻿using Almotkaml.MFMinistry.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace Almotkaml.MFMinistry
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum e)
        {
            var rm = new ResourceManager(typeof(Title));
            var resourceDisplayName = rm.GetString(e.GetType().Name);

            return string.IsNullOrWhiteSpace(resourceDisplayName) ? string.Format("[[{0}]]", e) : resourceDisplayName;
        }
    }
}
