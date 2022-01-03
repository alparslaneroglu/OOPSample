using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Services
{
    //Bir şirketin kayıt işlemleri register işlemleri sırasında böyle bir adresin olup olmadığını teyit etmek için sorgulama yapan servis.
    //Bu sorgulama servisi şuan için bir liste üzerinden kontrol edilecek olup ilerleyen zamanlarda e*devlet adres sorgulama sistemine bağlanabilir.
    public class NBuyCompanyAddressService : ICompanyAddressService

    {
        List<string> companyAddress = new List<string>();
       
        public NBuyCompanyAddressService()
        {
            companyAddress.Add("Yıldız, Çırağan Cd. No:32, 34349 Beşiktaş/İstanbul");
            companyAddress.Add("Bjk Plaza, Vişnezade Süleyman Seba Caddesi No:134 A Blok, Beşiktaş/İstanbul");
            companyAddress.Add("Sinanpaşa, Şair Nedim Cd. No:46/A, 34357 Beşiktaş/İstanbul");
        }
        public bool CheckAddress(string address)
        {
          return companyAddress.Any(cAddress => cAddress == address); // Any birşey varmı yokmu diye kontrol yapıyor. T-F diye döner.
            
        }
    }
}
