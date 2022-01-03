using OOPSample.Models;
using OOPSample.Services;
using System;

namespace OOPSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Not : Comany Adress Service ve TaxNumberLookUpService farklı şekillerde sorgulama yapbilme akbiliyetine sahip olsunlar diye company constructor içerisinde interfaceler üzerinden bağlantı kuruldu bu sayede company constructor içerisine gönderilen classlar ile adapte bir şekilde çalışması sağlandı.Polymorfpizm interface vasıtası ile uygulandı.
            //var company = new Company(name: "NBuy LTD,ŞTİ", address: "Yıldız, Çırağan Cd. No:32, 34349 Beşiktaş/İstanbul", taxNumber: "2323232323", companyAddressService: new NBuyCompanyAddressService(), taxNumberLookupService: new NBuyTaxNumberLookUpService());
            //company.SetPhoneNumber("0(212) 346 1010");
            var company1 = new Company(name: "NBUY LTD,ŞTİ", address: "Bjk Plaza, Vişnezade Süleyman Seba Caddesi No:134 A Blok, Beşiktaş/İstanbul", taxNumber: "1361341351412541", companyAddressService: new NBuyCompanyAddressService(), taxNumberLookupService: new NBuyTaxNumberLookUpService());
            
            var company2 = new Company(name: "NBUY İZMİR LTD,ŞTİ", address: "Sinanpaşa, Şair Nedim Cd. No:46/A, 34357 Beşiktaş/İstanbul", taxNumber: "23232323232", companyAddressService: new NBuyCompanyAddressService(), taxNumberLookupService: new NBuyTaxNumberLookUpService());
            


            var invoice = new Invoice(exporter: company1, consignee: company2);

            //var invoice2= new Invoice(exporter: company1, consignee: company2);
            //invoice2.Items.Add()
            //yukarıdaki kullanımı kapatarak sadece AddInvoiceItem methodu ile invoice'a item ekleme işlemi yaptık.
          //Birşey private ise _ kullanıyoruz.Yazım standartıdır.



            invoice.AddInvoiceItem(
               new InvoiceItem(
                   description: "Tasarım Bedeli",
                   unitPrice: 1000,
                   unitType: InvoiceUnitType.Daily,
                   amount: 5));
            invoice.AddInvoiceItem(
               new InvoiceItem(
                   description: "Yazılım Bedeli",
                   unitPrice: 300,
                   unitType: InvoiceUnitType.Hourly,
                   amount: 8));
            invoice.AddInvoiceItem(
               new InvoiceItem(
                   description: "Sosyal Medya Hizmet Bedeli",
                   unitPrice: 5000,
                   unitType: InvoiceUnitType.Hourly,
                   amount: 1));

           


            Console.WriteLine("Hello World!");
        }
    }
}