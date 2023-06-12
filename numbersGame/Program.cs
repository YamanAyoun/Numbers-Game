namespace numbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();// Call the StartSequence method 
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);// Handle FormatException if the input invalid format
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Number is too large or too small: " + ex.Message);//if number is too large or too small
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");//complete message
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");
            Console.WriteLine("Please enter a number greater than zero");
            int size = Convert.ToInt32(Console.ReadLine());// Convert input to integer

            int[] numbers = new int[size];
            numbers = Populate(numbers);// Call the Populate method

            int sum = GetSum(numbers);// Call the GetSum method
            int product = GetProduct(numbers, sum);// Call the GetProduct method
            decimal quotient = GetQuotient(product);// Call the GetQuotient method

            Console.WriteLine($"Your array is size = {numbers.Length}");
            
            /*for (int i = 0; i <= numbers.Length; i++)
            {
                Console.WriteLine($"The numbers in the array are = {numbers[i]}");
            };*/
            Console.WriteLine($"The Sum of the array is: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Quotient: {quotient}");
        }

        static int[] Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Please enter number: {i + 1} of {numbers.Length}");
                string input = Console.ReadLine();
                numbers[i] = Convert.ToInt32(input);// Convert the input to an integer and store it in the array

            }

            return numbers;
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                // Add each number to the sum
                sum += num;
            }
            //Check if the sum is less than 20
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }

            return sum;
        }

        static int GetProduct(int[] numbers, int sum)
        {
            Console.WriteLine($"Select a random number between 1 and {numbers.Length}:");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            // Check if the index is out of range
            if (index < 0 || index >= numbers.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            int product = sum * numbers[index];
            return product;
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Enter a number to divide {product} by:");
            decimal dividend = Convert.ToDecimal(Console.ReadLine());

            // Check if the dividend equal zero
            if (dividend == 0)
            {
                Console.WriteLine("Cannot divide by zero");
                return 0;
            }
            // if not 0 divide quotient
            decimal quotient = decimal.Divide(product, dividend);
            return quotient;
        }
    }
    }