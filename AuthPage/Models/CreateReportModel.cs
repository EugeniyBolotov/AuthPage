namespace AuthPage.Models
{
    public class CreateReportModel
    {
        public DateTime? inspectionDate { get; set; }
        public UserPicker inspector { get; set; }
        public string workspaceComment { get; set; }
        public string dutyNumber { get; set; }
        public string workDescription { get; set; }
        public string violiationDescription { get; set; }
        public DateTime? executionPeriod { get; set; }
        public bool isVioliationEliminated { get; set; }
        public string violationReason { get; set; }
        public string correctionDescription { get; set; }
        public string correctionResponsible {  get; set; }
        public int correctionStatus { get; set; }
    }
}
