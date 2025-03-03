namespace SWECVI.ApplicationCore.ViewModels
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string CompanyId { get; set; } = default!;
        public string Name { get; set; } = default!;
    }

    public class CompanyForSelectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
