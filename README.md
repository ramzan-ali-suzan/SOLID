# 🧱 SOLID Principles

SOLID is five fundamental principles of object-oriented design for loosely coupled, testable and maintainable software.

- [Single Responsibility Principle (SRP)](https://github.com/ramzan-ali-suzan/SOLID#single-responsibility-principle)
- Open/Closed Principle (OCP)
- Liskov Substitution Principle (LSP)
- Interface Segregation Principle (ISP)
- Dependency Inversion Principle (DIP)

## Why SOLID matters?

Because poor software quality costs $150+ billion per year in the US and over $500 billion worldwide. - [Capers Jones](http://www.sqgne.org/presentations/2010-11/Jones-Nov-2010.pdf)

# Single Responsibility Principle

> Each software module should have one and only one reason to change

## Some related terms

- **module** could be a service, a package, a class or a method
- **reason to change** refers to responsibility, some example of
  responsibility could be persistence, logging, validation or business logic
- **cohesion** refers to the degree with which elements of code belong together
- **coupling** is the manner of independence between modules of a programming system

## Benefits

- Low-coupling
- High-cohesion
- More testable

## Example

#### ❌ Violation

    public class InvitationService
    {
        public void SendInvite(string email, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Name is not valid!");
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Email is not valid!");
            }

            Console.WriteLine($"\nSending invitation to {firstName} {lastName}, at email {email}...\n");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                var invitationService = new InvitationService();

                while (true)
                {
                    // Taking input
                    Console.WriteLine("Enter participant first name:");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Enter participant last name:");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Enter participant email address:");
                    string email = Console.ReadLine();

                    // Sending Invitation
                    invitationService.SendInvite(email, firstName, lastName);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

#### ✅ Refactor

    public class UserNameService
    {
        public void Validate(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("The user name is invalid!");
            }
        }
    }

    public class EmailService
    {
        public void Validate(string email)
        {
            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new Exception("Email is not valid!");
            }
        }
    }

    public class InvitationService
    {
        UserNameService userNameService = new UserNameService();
        EmailService emailService = new EmailService();

        public void SendInvite(string email, string firstName, string lastName)
        {
            userNameService.Validate(firstName, lastName);
            emailService.Validate(email);

            Console.WriteLine($"\nSending invitation to {firstName} {lastName}, at email {email}...\n");
        }
    }

    partial class Program
    {
        static void Main()
        {
            try
            {
                var invitationService = new InvitationService();

                while (true)
                {
                    // Taking input
                    Console.WriteLine("Enter participant first name:");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Enter participant last name:");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Enter participant email address:");
                    string email = Console.ReadLine();

                    // Sending Invitation
                    invitationService.SendInvite(email, firstName, lastName);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

## Some great links

- [🎞️ SOLID Principles for C# Developers by Steve Smith @ Pluralsight](https://app.pluralsight.com/library/courses/csharp-solid-principles/table-of-contents)
- [🎞️ SOLID Principles by TechTong @ Youtube (বাংলা)](https://www.youtube.com/watch?v=9cEMm3K9DcI&list=PL-V21Ub1adxDgpwN28zPU27otvAVB13_L&ab_channel=TechTong)
- [📃 SOLID Principles by Matthew Jones](https://exceptionnotfound.net/tag/solidprinciples/)

## Give a Star! ⭐

If you like this project please give it a star. Thanks!
