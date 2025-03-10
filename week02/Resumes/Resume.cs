using System;

public class Resume
{
    public string _personName;
    public List<Job> _jobs = new List<Job>();

    public void DisplayResumeDetails()
    {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine("Jobs:");
        foreach (Job myJob in _jobs)
        {
            myJob.DisplayJobDetails();
        }
    }
}
