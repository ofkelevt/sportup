namespace sportup.Dtos
{
    public class ReportDto
    {
        public int ReportId { get; set; }
        public int ReportedById { get; set; }
        public int ReportedAgainstId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public Models.Report ToModelsReport(ReportDto dto)
        {
            return new Models.Report()
            {
                ReportId = dto.ReportId,
                ReporterId = dto.ReportedById,
                TargetId = dto.ReportedAgainstId,
                Comment = dto.Text,
                CreatedAt = dto.CreatedAt
            };
        }

        // Empty builder
        public ReportDto() { }

        // Builder that accepts a Report model
        public ReportDto(Models.Report report)
        {
            ReportId = report.ReportId;
            ReportedById = report.ReporterId;
            ReportedAgainstId = report.TargetId;
            Text = report.Comment;
            CreatedAt = report.CreatedAt;
        }
    }
}
