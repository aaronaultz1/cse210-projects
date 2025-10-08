using System;



public class Assignment
{
    protected string _studentName;
    private string _topic;

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }
    public string GetSummary()
    {
        return $"{_studentName}, {_topic}";
    }
}
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, string textbookSection, string problems) : base(name, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeWorkList()
    {
        return $"{_textbookSection} {_problems}";
    }
}

public class WritingAssignment : Assignment
{
    private string _title;
    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }
}

