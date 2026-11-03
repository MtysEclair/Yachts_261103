
namespace YachtStatistics
{
    public class Berles
    {
        public int Uid { get; set; }
        public int YachtId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DailyPrice { get; set; }
        public string Name { get; set; } = "";

        public int Days => (EndDate - StartDate).Days + 1;

        public int TotalPrice => Days * DailyPrice;
    }
}
