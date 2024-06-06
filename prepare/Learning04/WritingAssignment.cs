// Derived class representing a Writing assignment
public class WritingAssignment : Assignment
{
    // Private member variable specific to Writing assignments
    private string _title;

    // Constructor to initialize the Writing assignment details
    // Calls the base class constructor to set the student name and topic
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to return the writing information for the Writing assignment
    public string GetWritingInformation()
    {
        // Uses the GetStudentName method from the base class to get the student's name
        return $"{_title} by {GetStudentName()}";
    }
}
