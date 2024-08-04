namespace AuthPage.Models
{
    public class ReportListModel
    {
        public List<ReportModel> reports { get; set; }
        public ReportListModel()
        { 
            reports = new List<ReportModel>(); 
        }
    }
}
