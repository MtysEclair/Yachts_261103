
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YachtApi.Models
{
    public class Berles
    {
        public int Id { get; set; }

        public int Uid { get; set; }

        public int YachtId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DailyPrice { get; set; }

        public int Deposit { get; set; }

        [NotMapped]
        public int TotalPrice =>
            ((EndDate.Date - StartDate.Date).Days + 1)
            * DailyPrice;
    }
}
