using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Services
{
    class NBuyTaxNumberLookUpService : ITaxNumberLookupService
    {
        public List<string> _taxNumber
        {
            get
            {
                return new List<string> { "2323232323", "23232323232", "23232323232424", "1361341351412541", "135153124125123" };
            }
        }
        public bool LookUp(string taxNumber)
        {
            return _taxNumber.Any(x => x == taxNumber);
        }
    }
}
