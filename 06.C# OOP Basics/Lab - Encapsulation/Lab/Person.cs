using System;

public class Person
{
    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }

            this.firstName = firstName;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }

            this.lastName = value;
        }
    }
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age connot be zero or negative integer");
            }

            this.age = value;
        }
    }

    public double Salary
    {
        get { return this.salary; }
        set
        {
            if (value < 400)
            {
                throw new ArgumentException("Salary connot be less than 460 leva");
            }

            this.salary = value;
        }

    }

    public void IncreaseSalary(double percent)
    {
        if (this.Age > 30)
        {
            this.Salary += this.Salary * percent / 100;
        }
        else
        {
            this.Salary += this.Salary * percent / 200;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} get {this.Salary:f2} leva";
    }
}
