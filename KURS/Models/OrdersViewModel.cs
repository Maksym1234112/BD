using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KURS.Models
{
    public class OrdersViewModel
    {
        public int Id { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        
        [DisplayName("TypeOfProduct")]
        public string TypeOfProduct { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
        public double Price { get; set; }

        [DisplayName("Product")]
        public string FullTitle
        {
            get { return Title + " - " + TypeOfProduct; }
        }
    }
}
