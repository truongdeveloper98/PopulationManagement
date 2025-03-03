namespace SWECVI.ApplicationCore.ViewModels
{
    public class PagedRequestDto
    {
        public int CurrentPage { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string? SortColumnDirection { get; set; } = "DESC";
        public string? SortColumnName { get; set; } = "";
        public string? TextSearch { get; set; } = "";
    }
}
