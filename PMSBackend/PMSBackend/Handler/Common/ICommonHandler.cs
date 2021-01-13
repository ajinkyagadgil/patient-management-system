using PMSBackend.Handler.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMSBackend.Handler.Common
{
    public interface ICommonHandler
    {
        List<GenderViewModel> GetGenders();
    }
}
