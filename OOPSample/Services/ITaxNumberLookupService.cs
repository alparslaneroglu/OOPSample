using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Services
{
    //Vergi numarası sorbgulamasa servisi 
    //Gerçekten böyhle bir vergi numarası olup olmadığını sorgulamak için yazdık.
    public interface ITaxNumberLookupService
    {
        //biziim bir vergi numarası sorgulama sitemiz olsun
        //bu sorgulama sisteminin nasıl çalıştığını bilmiyoruz yada farklı şekillerde soruglamaf olabilir sistemde bu sebeple işin özetini yazıp .Detayaını ise ilgili servislerde yazacağız.Abstraction
        bool LookUp(string taxNumber);
    }
}
