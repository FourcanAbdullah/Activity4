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
    
    public string classroomPub
    {
        get
        {
            
            return classroomPub;
            
        }

    }

    
    public string CollegePub
    {
        get
        {
 
             return CollegePub;
            
        }
    }

    void StudentClass();
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
    public string studentYearPub = "2050";
    public string classroomPub = "Online API Class";
    public string CollegePub = "Hunter College";
    

    public void StudentClass()
	{
		Console.WriteLine($"Student is taking a {classroomPub}");
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
		Fourcan.StudentClass();
		Fourcan.StudentCollege();
		Fourcan.StudentBirthYear();



	}
}
