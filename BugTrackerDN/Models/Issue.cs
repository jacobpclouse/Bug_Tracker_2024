// Models/Issue.cs
using System.ComponentModel.DataAnnotations;
namespace BugTrackerDN.Models;

public class Issue
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Reporter { get; set; }
}

// add more attributes like the following: 
/*
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
*/