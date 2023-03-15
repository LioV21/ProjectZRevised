namespace HealthApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // This application is an intake form for collecting health-related information from users.

            string firstName;
            string lastName;
            int birthYear;
            char gender;

            // Accept user inputs
            do
            {
                Console.Write("Enter your first name: ");
                firstName = Console.ReadLine();
            } while (string.IsNullOrEmpty(firstName) || firstName.Any(char.IsDigit) || firstName.Any(char.IsSymbol));

            do
            {
                Console.Write("Enter your last name: ");
                lastName = Console.ReadLine();
            } while (string.IsNullOrEmpty(lastName) || lastName.Any(char.IsDigit) || lastName.Any(char.IsSymbol));

            do
            {
                Console.Write("Enter your birth year (yyyy): ");
                try
                {
                    birthYear = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    birthYear = -1;
                }
            } while (birthYear < 1900 || birthYear > DateTime.Now.Year);

            do
            {
                Console.Write("Enter your gender (M/F/O): ");
                gender = Convert.ToChar(Console.ReadLine().ToUpper());
            } while (gender != 'M' && gender != 'F' && gender != 'O');

            // Create and store user responses in a list
            List<string> responses = new List<string>();
            Console.WriteLine("Please answer the following questions:");

            string[] questions = new string[]
            {
                "Do you run daily?",
                "Do you go to the gym daily?",
                "How many push ups are you able to do?",
                "How much can you lift?",
                "Do you eat a balanced diet?",
                "How many hours of sleep do you get per night?",
                "How many glasses of water do you drink per day?",
                "Do you smoke or use tobacco products?",
                "Do you drink alcohol?",
                "Do you have any medical conditions we should be aware of?"
            };

            for (int i = 0; i < questions.Length; i++)
            {
                string response;
                do
                {
                    Console.Write($"Question {i + 1}: {questions[i]} ");
                    response = Console.ReadLine();
                } while (string.IsNullOrEmpty(response));
                responses.Add(response);
            }

            // Display user profile summary
            Console.WriteLine("===== User Profile Summary =====");
            Console.WriteLine($"Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetGenderDescription(gender)}");

            Console.WriteLine("************ Your Responses ************");

            for (int i = 0; i < responses.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");
                Console.WriteLine($"Response {i + 1}: {responses[i]}");
                Console.WriteLine("****************************************");
            }
        }

        // Get gender description based on input
        /// <summary>
        /// Returns the full description of the user's gender based on the input character.
        /// </summary>
        /// <param name="gender">The user's gender character (M/F/O).</param>
        /// <returns>The full description of the user's gender (Male/Female/Other not listed).</returns>
        private static string GetGenderDescription(char gender)
        {
            switch (gender)
            {
                case 'M':
                    return "Male";
                case 'F':
                    return "Female";
                case 'O':
                    return "Other not listed";
                default:
                    throw new ArgumentException("Gender is invalid.");
            }
        }
    }
}
