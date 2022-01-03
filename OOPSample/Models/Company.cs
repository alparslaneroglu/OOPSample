using OOPSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Models
{
    public class Company
    {
        public string Name { get; private set; } // Bunları dışarıdan alamıyoruz.Çünkü bunlar olmadan şirket olmaz
        public string Address { get; private set; }

        //Vergi No:
        public string TaxNumber { get; private set; }
        //Şirket Hattı
        public string PhoneNumber { get; set; }

        //adresleri sisteme company olarak girmeden önce bu servis ile adres sorgulaması yapacağız.
        //Private bir field.
        private ICompanyAddressService _companyAddressService;
        private ITaxNumberLookupService _taxNumberLookUpService;
        public Company(string name, string address,string taxNumber,ICompanyAddressService companyAddressService, ITaxNumberLookupService taxNumberLookupService)
        {
            _companyAddressService = companyAddressService;
            _taxNumberLookUpService = taxNumberLookupService;
            SetCompanyName(name);
            SetAddress(address);
            SetTaxNumber(taxNumber);
        }
        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))

            {
                throw new Exception("Telefon numarası boş geçilemez");

            }
            PhoneNumber = phoneNumber;
        }
        private void SetTaxNumber(string taxNumber)
        {
            var result = _taxNumberLookUpService.LookUp(taxNumber);
            if (!result)
            {
                throw new Exception("Böyle bir vergi numarası sistemde mevcut değildir.");
            }
            TaxNumber = taxNumber;
        }


        //string alanları sisteme kaydederken her zaman için trim kontrolü yapıyoruz.
        private void SetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception("Adres alanı boş geçilemez..");
            }
            if (address.Length<20)
            {

                throw new Exception("Minimum 20 karakterden oluşmalıdır.");
            }
            var result = _companyAddressService.CheckAddress(address);
            //adres onaylanmadıysa hata ver
            if (result==false)
            {
                throw new Exception("Böyle bir adres sistemde bulunamamıştır..");
            }
            //AddressService ile bu adresingerçekte olup olmadığını teyit etmemiz gerekebilir.
            Address = address.Trim();
        }
        private void SetCompanyName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Şirket adı boş geçilemez");
            }
            //kullanıcı input içerisinden name alanını ön arkasında boşluklu girebilir bu boşlukları sisteme girmeden önce kaldırıyoruz.
            Name = name.Trim();
        }
    }
}
