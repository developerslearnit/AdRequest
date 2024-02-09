namespace AdmonRequest.WebUI.ReportParamsModel
{
    public class RequestReportParamModel
    {
        public bool ViewByDate { get; set; }=false;
        public bool ViewByStatus { get; set; } =false;
        public string Status { get; set; }=string.Empty;
        public string StartDate { get; set; } =string.Empty;
        public string EndDate { get; set; }= string.Empty;
    }
}


