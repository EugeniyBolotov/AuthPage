namespace AuthPage.Models
{
    public class ReportModel
    {
        public int id { get; set; }
        public DateTime? inspectionDate { get; set; }
        public UserPicker inspector { get; set; }
        public string workspaceComment { get; set; }
        public string dutyNumber { get; set; }
        public string workDescription { get; set; }
        public string company { get; set; }
        public string typology { get; set; }
        public string manufacturer { get; set; }
        public string violiationDescription { get; set; }
        public DateTime? executionPeriod { get; set; }
        public bool isVioliationEliminated { get; set; }
        public string violationReason { get; set; }
        public string correctionDescription { get; set; }
        public string correctionResponsible {  get; set; }
        public int correctionStatus { get; set; }

        public string GetInspectorFullName()
        {
            return inspector.fullName;
        }
    }
}
