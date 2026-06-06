using LoginApp.Models;
using LoginApp.Services;

List<User> users = new()
{
    new User
    {
        Username = "admin",
        Password = "password123"
    }
};

var registrationService = new RegistrationService(users);
var authService = new AuthService();

while (true)
{
    Console.Clear();

    Console.WriteLine("==================================");
    Console.WriteLine("          LOGIN SYSTEM");
    Console.WriteLine("==================================");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");
    Console.WriteLine();

    Console.Write("Enter Choice: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            Console.Write("\nEnter Username: ");
            string username = Console.ReadLine()!;

            Console.Write("Enter Password: ");
            string password = ReadPassword();

            try
            {
                bool result =
                    registrationService.Register(username, password);

                Console.WriteLine();

                if (result)
                    Console.WriteLine("Registration Successful!");
                else
                    Console.WriteLine("Username already exists!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
            break;

        case "2":

            Console.Write("\nEnter Username: ");
            string loginUser = Console.ReadLine()!;

            Console.Write("Enter Password: ");
            string loginPassword = ReadPassword();

            var user =
                users.FirstOrDefault(u =>
                    u.Username.Equals(
                        loginUser,
                        StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                Console.WriteLine("\nUser not found!");
                Pause();
                break;
            }

            try
            {
                bool result =
                    authService.Login(
                        user,
                        loginUser,
                        loginPassword);

                Console.WriteLine();

                if (result)
                {
                    Console.WriteLine("Login Successful!");
                    Console.WriteLine($"Welcome {user.Username}");
                }
                else
                {
                    Console.WriteLine("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Pause();
            break;

        case "3":

            Console.WriteLine("\nThank you for using LoginApp.");
            return;

        default:

            Console.WriteLine("\nInvalid Choice!");
            Pause();
            break;
    }
}

static string ReadPassword()
{
    string password = "";

    ConsoleKeyInfo key;

    do
    {
        key = Console.ReadKey(true);

        if (key.Key != ConsoleKey.Backspace &&
            key.Key != ConsoleKey.Enter)
        {
            password += key.KeyChar;
            Console.Write("*");
        }
        else if (key.Key == ConsoleKey.Backspace &&
                 password.Length > 0)
        {
            password = password[..^1];
            Console.Write("\b \b");
        }

    } while (key.Key != ConsoleKey.Enter);

    Console.WriteLine();

    return password;
}

static void Pause()
{
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}