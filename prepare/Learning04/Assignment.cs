// Base class representing a general assignment
public class Assignment
{
    // Private member variables to store the student's name and the topic of the assignment
    private string _studentName;
    private string _topic;

    // Constructor to initialize the student name and topic
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return a summary of the assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Method to return the student's name
    public string GetStudentName()
    {
        return _studentName;
    }
}
