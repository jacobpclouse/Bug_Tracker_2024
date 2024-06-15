namespace Bug_Tracker_2024.Models  // Ensure namespace matches project structure
{
// Issue.cs
    public class Issue
    {
        public int Id { get; set; }
        public string IssueReporter { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueTitle { get; set; }
        public string IssueDescription { get; set; }
        public string IssueType { get; set; }
        public string ReporterPhone { get; set; }
        public string ReporterEmail { get; set; }
        public string IssueLocation { get; set; }
        public bool IssueAssigned { get; set; }
        public bool IssueResolved { get; set; }
        public string IssueAssignee { get; set; }
    }
}