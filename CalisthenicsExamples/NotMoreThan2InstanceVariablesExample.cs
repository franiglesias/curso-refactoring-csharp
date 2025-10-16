// Translated from CalisthenicsExamples/not-more-than-2-instance-variables.ts
// Demonstrates splitting data across small objects but the Report still coordinates multiple parts
using System;
using System.Text;

namespace CalisthenicsExamples
{
    public class Report
    {
        private readonly ReportContent content;
        private readonly ReportMetadata metadata;

        public Report(ReportContent content, ReportMetadata metadata)
        {
            this.content = content;
            this.metadata = metadata;
        }

        public void PrintSummary()
        {
            var summary = "Report: {{title}} by {{author}} ({{createdAt}})";
            summary = this.content.Print(summary);
            summary = this.metadata.Print(summary);
            System.Console.WriteLine(summary);
        }
    }

    public class ReportContent
    {
        private readonly string title;
        private readonly string content;

        public ReportContent(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public string Print(string template)
        {
            return template.Replace("{{title}}", this.title)
                           .Replace("{{content}}", this.content);
        }
    }

    public class ReportMetadata
    {
        private readonly string author;
        private readonly System.DateTime createdAt;
        private readonly System.Collections.Generic.List<string> tags;

        public ReportMetadata(string author, System.DateTime createdAt, System.Collections.Generic.List<string> tags)
        {
            this.author = author;
            this.createdAt = createdAt;
            this.tags = tags;
        }

        public string Print(string template)
        {
            return template
                .Replace("{{author}}", this.author)
                .Replace("{{createdAt}}", this.createdAt.ToShortDateString())
                .Replace("{{tags}}", string.Join(", ", this.tags));
        }
    }
}
