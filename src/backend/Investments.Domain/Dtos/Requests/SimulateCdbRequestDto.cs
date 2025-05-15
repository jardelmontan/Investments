namespace Investments.Domain.Dtos.Requests
{
    public class SimulateCdbRequestDto
    {
        public decimal InitialAmount { get; set; }
        public int TotalMonths { get; set; }
    }
}
