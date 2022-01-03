using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSample.Models
{
    public class Invoice
    {
        public DateTime InvoiceDate { get; private set; }
        //faturayı kesen
        public Company Exporter { get; private set; }
         //mal hizmet alan firma
        public Company Consignee { get; private set; }
        public decimal TotalPrice { get; private set; }
        private List<InvoiceItem> _items = new List<InvoiceItem>();
        // list item read only olarak işaretleyip sadece bulananın get edilebileceğini söylemiş olduk.
        public IReadOnlyList<InvoiceItem> Items => _items;

        //public IReadOnlyList<InvoiceItem> Items2
        //ReadOnly olan koleksiyolnarın add methodu yoktur.
        //Yukarıdaki aynı kod.
        //{
        //    get
        //    {
        //        return _items;
        //    }
        //}

        //faturaya fatura ike alakalı hizmetlerin listesini ekledğimiz method
        public string  Id { get; private set; }
        //Fatura kesmek için faturayı kesen ve fatura kesilen firma bilgilerini bilmeniz yeterlidir.
        public Invoice(Company exporter,Company consignee)
        {
            //fatura kesim tarihi işlem yapılan bir tarih olmalıdır.
            //dışarıdan bu bilgiyi almıyoruz.
            Id = Guid.NewGuid().ToString();
            InvoiceDate = DateTime.Now;
            Exporter = exporter;
            Consignee = consignee;
        }

      
        public void AddInvoiceItem(InvoiceItem item)
        {
            //item eklemeden önce elimizdeki inoice item count üzerinden kaçıncı sırada olduğumuzu bildiğmiz için +1 artırarak sequence number güncelledk.
            item.SetSequenceNumber(Items.Count+1);
            _items.Add(item);
            //her bir item eklendğinide bu item ait list pricelerın toplamı
            TotalPrice += item.ListPrice;
            
        }
    }
}
