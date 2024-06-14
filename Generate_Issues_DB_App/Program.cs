using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class StackOverflowIssue
{
    public int Id { get; set; }
    public string IssueReporter { get; set; }
    public DateTime IssueDate { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
    public List<string> IssueType { get; set; }

    public string ReporterPhone { get; set; }
    public string ReporterEmail { get; set; }
    public string IssueLocation { get; set; }
    public bool IssueAssigned { get; set; }
    public bool IssueResolved { get; set; }
    public string IssueAssignee { get; set; }
}

public static class DataGenerator
{
    private static readonly Random random = new Random();
    private static readonly List<string> Cities = new List<string> 
    {
        "Albany, NY", "Austin, TX", "Chicago, IL", "Denver, CO", "Los Angeles, CA"
        // Add more cities as needed
    };

    public static void GenerateAdditionalFields(StackOverflowIssue issue)
    {
        issue.ReporterPhone = GeneratePhoneNumber();
        issue.ReporterEmail = $"{issue.IssueReporter.Replace(" ", "").ToLower()}@dundermifflin.org";
        issue.IssueLocation = Cities[random.Next(Cities.Count)];
        issue.IssueAssigned = false;
        issue.IssueResolved = false;
        issue.IssueAssignee = null;
    }

    private static string GeneratePhoneNumber()
    {
        return $"{random.Next(100, 1000)}-{random.Next(100, 1000)}-{random.Next(1000, 10000)}";
    }
}

public static class DatabaseHelper
{
    public static void CreateDatabase()
    {
        using var connection = new SQLiteConnection("Data Source=issues2024.db;Version=3;");
        connection.Open();

        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Issues (
                Id INTEGER PRIMARY KEY,
                IssueReporter TEXT,
                IssueDate TEXT,
                IssueTitle TEXT,
                IssueDescription TEXT,
                IssueType TEXT,
                ReporterPhone TEXT,
                ReporterEmail TEXT,
                IssueLocation TEXT,
                IssueAssigned BOOLEAN,
                IssueResolved BOOLEAN,
                IssueAssignee TEXT
            )";
        using var command = new SQLiteCommand(createTableQuery, connection);
        command.ExecuteNonQuery();
    }

    public static void InsertIssue(StackOverflowIssue issue)
    {
        using var connection = new SQLiteConnection("Data Source=issues2024.db;Version=3;");
        connection.Open();

        string insertQuery = @"
            INSERT INTO Issues (Id, IssueReporter, IssueDate, IssueTitle, IssueDescription, IssueType, ReporterPhone, ReporterEmail, IssueLocation, IssueAssigned, IssueResolved, IssueAssignee)
            VALUES (@Id, @IssueReporter, @IssueDate, @IssueTitle, @IssueDescription, @IssueType, @ReporterPhone, @ReporterEmail, @IssueLocation, @IssueAssigned, @IssueResolved, @IssueAssignee)";
        
        using var command = new SQLiteCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@Id", issue.Id);
        command.Parameters.AddWithValue("@IssueReporter", issue.IssueReporter);
        command.Parameters.AddWithValue("@IssueDate", issue.IssueDate);
        command.Parameters.AddWithValue("@IssueTitle", issue.IssueTitle);
        command.Parameters.AddWithValue("@IssueDescription", issue.IssueDescription);
        command.Parameters.AddWithValue("@IssueType", string.Join(",", issue.IssueType));
        command.Parameters.AddWithValue("@ReporterPhone", issue.ReporterPhone);
        command.Parameters.AddWithValue("@ReporterEmail", issue.ReporterEmail);
        command.Parameters.AddWithValue("@IssueLocation", issue.IssueLocation);
        command.Parameters.AddWithValue("@IssueAssigned", issue.IssueAssigned);
        command.Parameters.AddWithValue("@IssueResolved", issue.IssueResolved);
        command.Parameters.AddWithValue("@IssueAssignee", (object)issue.IssueAssignee ?? DBNull.Value);

        command.ExecuteNonQuery();
    }
}

public class Program
{
    public static async Task Main(string[] args)
    {
        DatabaseHelper.CreateDatabase();

        var issues = await FetchStackOverflowIssuesAsync();
        foreach (var issue in issues)
        {
            DataGenerator.GenerateAdditionalFields(issue);
            DatabaseHelper.InsertIssue(issue);
        }

        Console.WriteLine("Issues fetched and stored successfully.");
    }

    public static async Task<List<StackOverflowIssue>> FetchStackOverflowIssuesAsync()
    {
        using HttpClient client = new HttpClient();
        string url = "https://api.stackexchange.com/2.2/questions?order=desc&sort=creation&site=stackoverflow";
        var response = await client.GetStringAsync(url);
        var json = JObject.Parse(response);

        var issues = new List<StackOverflowIssue>();
        foreach (var item in json["items"])
        {
            var issue = new StackOverflowIssue
            {
                Id = (int)item["question_id"],
                IssueReporter = (string)item["owner"]["display_name"],
                IssueDate = DateTimeOffset.FromUnixTimeSeconds((long)item["creation_date"]).DateTime,
                IssueTitle = (string)item["title"],
                IssueDescription = (string)item["body"],
                IssueType = item["tags"].ToObject<List<string>>()
            };
            issues.Add(issue);
        }

        return issues;
    }
}
