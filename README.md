# 🧱 SOLID Principles

SOLID is five fundamental principles of object-oriented design for loosely coupled, testable and maintainable software.

- Single Responsibility Principle (SRP)
- Open/Closed Principle (OCP)
- Liskov Substitution Principle (LSP)
- Interface Segregation Principle (ISP)
- Dependency Inversion Principle (DIP)

## Why SOLID matters?

Because poor software quality costs $150+ billion per year in the US and over $500 billion worldwide. - [Capers Jones](http://www.sqgne.org/presentations/2010-11/Jones-Nov-2010.pdf)

# Single Responsibility Principle

> Each software module should have one and only one reason to change

### Some related terms

- **module** could be a service, a package, a class or a method
- **reason to change** refers to responsibility, some example of
  responsibility could be persistence, logging, validation or business logic
- **cohesion** refers to the degree with which elements of code belong together
- **coupling** is the manner of independence between modules of a programming system

### Benefits

- Low-coupling
- High-cohesion
- More testable

### Example

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

<br>

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

<br>

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

<br>

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

<br>

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

# Open/Closed Principle

> Software entities (classes, modules, functions, etc.) should be open for extension, but closed of modification

It should be possible to change the behavior of a entity without editing its source code.

💡 Best example could be package or library which is used by many third parties.

### Typical approach to OCP

- Parameters
- Inheritance
- Composition/Injection
- Extension method

### Benefits

- Less likely to introduce bug
- Less likely to break dependent code
- Fewer condition

### Example

#### ❌ Violation

    public abstract class FoodItem
    {
        public string Name { get; set; }
    }

<br>

    public class FriedFood : FoodItem
    {
        public FriedFood(string name)
        {
            Name = name;
        }
    }

<br>

    public class GrilledFood : FoodItem
    {
        public GrilledFood(string name)
        {
            Name = name;
        }
    }

<br>

    public class KitchenService
    {
        public void PrepareItems(List<FoodItem> foodItems)
        {
            foreach (var item in foodItems)
            {
                if (item is GrilledFood)
                    Console.WriteLine($"Grilling {item.Name}...");

                if (item is FriedFood)
                    Console.WriteLine($"Frying {item.Name}...");
            }
        }
    }

<br>

    class Program
    {
        static void Main(string[] args)
        {
            var foodItems = new List<FoodItem>
            {
                new GrilledFood("steak"),
                new FriedFood("chicken")
            };

            KitchenService kitchenService = new KitchenService();
            kitchenService.PrepareItems(foodItems);
        }
    }

#### ✅ Refactor

    public abstract class FoodItem
    {
        public string Name { get; set; }

        public abstract void Prepare();
    }

<br>

    public class FriedFood : FoodItem
    {
        public FriedFood(string name)
        {
            Name = name;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Frying {Name}...");
        }
    }

<br>

    public class GrilledFood : FoodItem
    {
        public GrilledFood(string name)
        {
            Name = name;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Grilling {Name}...");
        }
    }

<br>

    public class BakedFood : FoodItem
    {
        public BakedFood(string name)
        {
            Name = name;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Baking {Name}...");
        }
    }

<br>

    public class KitchenService
    {
        public void PrepareItems(List<FoodItem> foodItems)
        {
            foreach (var item in foodItems)
            {
                item.Prepare();
            }
        }
    }

<br>

    class Program
    {
        static void Main(string[] args)
        {
            var foodItems = new List<FoodItem>
            {
                new GrilledFood("steak"),
                new FriedFood("chicken"),
                new BakedFood("pizza")
            };

            var kitchenService = new KitchenService();
            kitchenService.PrepareItems(foodItems);
        }
    }

# Liskov Substitution Principle

> Subtypes must be substitutable for their base type

LSP states that IS-A relationship is insufficient and should be replaced with IS-SUBSTITUTABLE for. This is inherently what polymorphism is about.

A common example could be square–rectangle/circle–ellipse problem.

### Detecting LSP violation

- Type checking
- Null checking
- Not implemented exception

### Benefits

- Keeps functionality intact
- Subclass can be treated as base-class

### Example

#### ❌ Violation

    public abstract class Bird
    {
        public abstract void Fly();
    }

<br>

    public class Duck : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Duck is flying...");
        }
    }

<br>

    public class Ostrich : Bird
    {
        public override void Fly()
        {
            throw new Exception("Ostrich can't fly!");
        }
    }

<br>

    class Program
    {
        static void Main()
        {
            var birds = new List<Bird>
            {
                new Duck(),
                new Ostrich()
            };

            // Let the birds fly
            foreach (var bird in birds)
            {
                try
                {
                    bird.Fly();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }

#### ✅ Refactor

    public abstract class Bird
    {
    }

<br>

    public abstract class FlyingBird : Bird
    {
        public abstract void Fly();
    }

<br>

    public class Duck : FlyingBird
    {
        public override void Fly()
        {
            Console.WriteLine("Duck is flying...");
        }
    }

<br>

    public class Ostrich : Bird
    {
    }

<br>

    public class Sparrow : FlyingBird
    {
        public override void Fly()
        {
            Console.WriteLine("Sparrow is flying...");
        }
    }

<br>

    class Program
    {
        static void Main()
        {
            var flyingBirds = new List<FlyingBird>
            {
                new Duck(),
                new Sparrow()
            };

            // Let the birds fly
            foreach (var bird in flyingBirds)
            {
                try
                {
                    bird.Fly();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }

# Interface Segregation Principle

> Clients should not be forced to depend on methods they do not use

Prefer small, concise interface over large fat ones.

### Detecting ISP violation

- Large interface
- Not implemented exception
- Code uses just a small subset of a large interface

### Benefits

- Loose coupling
- Easier testing

### Example

#### ❌ Violation

    public interface IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize { get; set; }
        public int Inseam { get; set; }
        public int HatSize { get; set; }
    }

<br>

    public class BaseballCap : IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize
        {
            get => throw new Exception("Not needed");
            set => throw new Exception("Not needed");
        }
        public int Inseam
        {
            get => throw new Exception("Not needed");
            set => throw new Exception("Not needed");
        }
        public int HatSize { get; set; }
    }
 
 <br>

    public class Jeans : IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize { get; set; }
        public int Inseam { get; set; }
        public int HatSize
        {
            get => throw new Exception("Not needed");
            set => throw new Exception("Not needed");
        }
    }

<br>

    class Program
    {
        static void Main()
        {
            var newJeans = new Jeans { Weight = 1.7, Inseam = 27, Stock = 10, WaistSize = 30 };
            var newCaps = new BaseballCap { Weight = .3, Stock = 15, HatSize = 22 };

            Console.WriteLine("Jeans details:");
            foreach (PropertyInfo property in typeof(Jeans).GetProperties())
            {
                try
                {
                    Console.WriteLine($"{property.Name}: {property.GetValue(newJeans)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

#### ✅ Refactor

    public interface IProduct
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
    }

<br>

    public interface IPants
    {
        public double WaistSize { get; set; }
        public int Inseam { get; set; }
    }

<br>

    public interface IHat
    {
        public int HatSize { get; set; }
    }

<br>

    public class Jeans : IProduct, IPants
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public double WaistSize { get; set; }
        public int Inseam { get; set; }
    }

<br>

    public class BaseballCap : IProduct, IHat
    {
        public int Stock { get; set; }
        public double Weight { get; set; }
        public int HatSize { get; set; }
    }

<br>

    class Program
    {
        static void Main(string[] args)
        {
            var newJeans = new Jeans { Weight = 1.7, Inseam = 27, Stock = 10, WaistSize = 30 };
            var newCaps = new BaseballCap { Weight = .3, Stock = 15, HatSize = 22 };

            Console.WriteLine("Jeans details:");
            foreach (PropertyInfo property in typeof(Jeans).GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(newJeans)}");
            }

            Console.WriteLine("\nCap details:");
            foreach (PropertyInfo property in typeof(BaseballCap).GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(newCaps)}");
            }
        }
    }


# Dependency Inversion Principle

> High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions.

### Some related terms

- **High level** more abstraction, business rules, process oriented, further from i/o
- **Low level** closer to i/o, plumbing code
- **New is glue**

### Typical approach to DIP

- Don't create your own dependencies
- Request dependencies from client
- Client injects dependencies as
    - Construction arguments
    - Properties
    - Method arguments

### Benefits

- Loose coupling
- Easier testing

### Example

#### ❌ Violation

    public class Customer
    {
        public Customer(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
    }

<br>

    public class ShoppingCart
    {
        public ShoppingCart(double totalAmount, Customer customer)
        {
            this.TotalAmount = totalAmount;
            this.Customer = customer;
        }

        public double TotalAmount { get; private set; }
        public Customer Customer { get; private set; }
    }

<br>

    public class SMSService
    {
        public void SendSMS(string text, string phoneNumber)
        {
            Console.WriteLine("Sending SMS via GP:");
            Console.WriteLine($"Receiver: {phoneNumber}");
            Console.WriteLine($"Text: {text}");
        }
    }

<br>

    public class CheckoutService
    {
        private readonly SMSService _smsService;

        public CheckoutService()
        {
            _smsService = new SMSService();
        }

        private void SendConfirmationSMS(ShoppingCart shoppingCart)
        {
            string message = $"Thank you, {shoppingCart.Customer.Name} for shopping at our store.\nYour order of total BDT {shoppingCart.TotalAmount} has been confirmed.";
            _smsService.SendSMS(message, shoppingCart.Customer.PhoneNumber);
        }

        public void Checkout(ShoppingCart shoppingCart)
        {
            Console.WriteLine($"Checking out {shoppingCart.Customer.Name}...");
            SendConfirmationSMS(shoppingCart);
        }
    }

<br>

    class Program
    {
        static void Main()
        {
            var customer = new Customer("Fazle Rabbi", "0155667788");
            var shoppingCart = new ShoppingCart(3500, customer);

            var checkoutService = new CheckoutService();
            checkoutService.Checkout(shoppingCart);
        }
    }

#### ✅ Refactor

    public class Customer
    {
        public Customer(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
    }

<br>

    public class ShoppingCart
    {
        public ShoppingCart(double totalAmount, Customer customer)
        {
            this.TotalAmount = totalAmount;
            this.Customer = customer;
        }

        public double TotalAmount { get; private set; }
        public Customer Customer { get; private set; }
    }

<br>

    public interface ISMSProvider
    {
        public void SendSMS(string text, string phoneNumber);
    }

<br>

    public class GPSMSProvider : ISMSProvider
    {
        public void SendSMS(string text, string phoneNumber)
        {
            Console.WriteLine("Sending SMS via GP:");
            Console.WriteLine($"Receiver: {phoneNumber}");
            Console.WriteLine($"Text: {text}");
        }
    }

<br>

    public class RobiSMSProvider : ISMSProvider
    {
        public void SendSMS(string text, string phoneNumber)
        {
            Console.WriteLine("Sending SMS via Robi:");
            Console.WriteLine($"Receiver: {phoneNumber}");
            Console.WriteLine($"Text: {text}");
        }
    }

<br>

    public class SMSService
    {
        private readonly ISMSProvider _smsProvider;

        public SMSService(ISMSProvider smsProvider)
        {
            _smsProvider = smsProvider;
        }

        public void SendSMS(string text, string phoneNumber)
        {
            _smsProvider.SendSMS(text, phoneNumber);
        }
    }

<br>

    public class CheckoutService
    {
        private readonly SMSService _smsService;

        public CheckoutService(SMSService smsService)
        {
            _smsService = smsService;
        }

        private void SendConfirmationSMS(ShoppingCart shoppingCart)
        {
            string message = $"Thank you, {shoppingCart.Customer.Name} for shopping at our store.\nYour order of total BDT {shoppingCart.TotalAmount} has been confirmed.";
            _smsService.SendSMS(message, shoppingCart.Customer.PhoneNumber);
        }

        public void Checkout(ShoppingCart shoppingCart)
        {
            Console.WriteLine($"Checking out {shoppingCart.Customer.Name}...");
            SendConfirmationSMS(shoppingCart);
        }
    }

<br>

    class Program
    {
        static void Main()
        {
            var customer = new Customer("Fazle Rabbi", "0155667788");
            var shoppingCart = new ShoppingCart(3500, customer);

            //var smsProvider = new GPSMSProvider();
            var smsProvider = new RobiSMSProvider();
            var smsService = new SMSService(smsProvider);

            var checkoutService = new CheckoutService(smsService);
            checkoutService.Checkout(shoppingCart);
        }
    }


## Some great links

- [🎞️ SOLID Principles for C# Developers by Steve Smith @ Pluralsight](https://app.pluralsight.com/library/courses/csharp-solid-principles/table-of-contents)
- [🎞️ SOLID Principles by TechTong @ Youtube (বাংলা)](https://www.youtube.com/watch?v=9cEMm3K9DcI&list=PL-V21Ub1adxDgpwN28zPU27otvAVB13_L&ab_channel=TechTong)
- [📃 SOLID Principles by Matthew Jones](https://exceptionnotfound.net/tag/solidprinciples/)

## Give a Star! ⭐

If you like this project please give it a star. Thanks!
