// Derived class representing a Math assignment
public class MathAssignment : Assignment
{
    // Private member variables specific to Math assignments
    private string _textbookSection;
    private string _problems;

    // Constructor to initialize the Math assignment details
    // Calls the base class constructor to set the student name and topic
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method to return the homework list for the Math assignment
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
