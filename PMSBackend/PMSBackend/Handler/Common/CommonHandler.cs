using Patient.Core.Common.Enums;
using PMSBackend.Handler.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PMSBackend.Handler.Common
{
    public class CommonHandler : ICommonHandler
    {
        public List<GenderViewModel> GetGenders()
        {
            return ((Gender[])Enum.GetValues(typeof(Gender))).Select(x => new GenderViewModel { id = (int)x, name = x.ToString() }).ToList();
        }
    }
}
