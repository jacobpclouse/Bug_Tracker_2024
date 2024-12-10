// Models/Issue.cs
using System.ComponentModel.DataAnnotations;
namespace BugTrackerDN.Models;

public class Issue
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Reporter { get; set; }
}