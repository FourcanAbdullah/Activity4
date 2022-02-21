// See https://aka.ms/new-console-template for more information
using System;

interface Students
{
    public string studentNamePub
    {
        get
        {
            return studentNamePub;
        }
        set
        {
            studentNamePub = value;
        }
    }

    public int studentYearPub
    {
        get
        {
            
            return studentYearPub;
            
        }

    }
    
    public double gpaPub
    {
        get
        {
            
            return gpaPub;
            
        }

    }

    
    public string CollegePub
    {
        get
        {
 
             return CollegePub;
            
        }
    }

    void StudentGPA();
	void StudentBirthYear();
	void StudentCollege();


};

interface Services 
{
	void OnStudentUnknown(object source, EventArgs args);
}


public class StudentInformation : Students
{
	public delegate void StudentUnknownEventHandler(object source, EventArgs args);

	public event StudentUnknownEventHandler StudentUnknown = null!;

	protected virtual void OnStudentUnknown()
    {
		if (StudentUnknown != null)
			StudentUnknown(this, null!);
    }
    public string studentNamePub = "Fourcan";
    public int studentYearPub = 2050;
    public double gpaPub = 3.2;
    public string CollegePub = "Hunter College";
    

    public void StudentGPA()
	{
		Console.WriteLine($"Student has a {gpaPub} GPA");
		OnStudentUnknown();
	}
	public void StudentBirthYear()
	{
		Console.WriteLine($"Student is Born in {studentYearPub}");
		OnStudentUnknown();

	}
	public void StudentCollege()
	{
		Console.WriteLine($"Student is in {CollegePub}");
		OnStudentUnknown();

	}
	public void StudentName()
	{
		Console.WriteLine($"Student is '{studentNamePub}', this is his information: ");
	}
};

public class StudentServices: Services
{
	public void OnStudentUnknown(object source, EventArgs args)
    {
		Console.WriteLine("Student Information has been retrieved");
    }
	
}

class Program
{
	static void Main(string[] args)
	{
		StudentInformation Fourcan = new StudentInformation();
		StudentServices StudentService = new StudentServices();
		Fourcan.StudentUnknown += StudentService.OnStudentUnknown;
		Fourcan.StudentName();
		Fourcan.StudentGPA();
		Fourcan.StudentCollege();
		Fourcan.StudentBirthYear();



	}
}
