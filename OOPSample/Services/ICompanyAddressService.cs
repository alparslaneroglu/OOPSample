using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Services
{
    public interface ICompanyAddressService
    {
        //böyle bir adres varmı yok mu kontrolü yapan interface ait method.
        bool CheckAddress(string address);
    }
}
