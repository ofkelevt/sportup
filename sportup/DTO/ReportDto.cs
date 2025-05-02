using sportup.Models;

namespace sportup.DTO
{
    public class ReportDto
    {
        public int ReportId { get; set; }
        public int ReporterId { get; set; }
        public int TargetId { get; set; }
        public string? CommentText { get; set; }
        public DateTime CreatedAt { get; set; }

        public ReportDto() { }

        public ReportDto(Report report)
        {
            ReportId = report.ReportId;
            ReporterId = report.ReporterId;
            TargetId = report.TargetId;
            CommentText = report.CommentText;
            CreatedAt = report.CreatedAt;
        }

        public Report ToModel()
        {
            return new Report
            {
                ReportId = ReportId,
                ReporterId = ReporterId,
                TargetId = TargetId,
                CommentText = CommentText,
                CreatedAt = CreatedAt
            };
        }
    }

}
