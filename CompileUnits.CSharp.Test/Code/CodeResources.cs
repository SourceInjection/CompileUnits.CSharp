namespace CompileUnits.CSharp.Test.Code
{
    internal class CodeResources
    {
        private static readonly string[] TestStrings =
        {
            "{ { if(true) { } else { } } }"
        };

        private static readonly string[] ChatGptExamples =
        {
            @"// Block 1: Basic Arithmetic and Assignments
int a = 5;
int b = 10;
int sum = a + b;
int difference = b - a;
int product = a * b;
int quotient = b / a;
int remainder = b % a;
a += 2;
b -= 3;
a *= 4;
b /= 2;
sum = (a + b) * (b - a);
bool isEqual = a == b;
bool isNotEqual = a != b;
bool isGreater = a > b;
bool isLess = a < b;
bool isGreaterOrEqual = a >= b;
bool isLessOrEqual = a <= b;
int combined = (a + b) * (a - b) / (a % 2);
string text = ""Hello"";
text += "" World!"";
bool isNullOrEmpty = string.IsNullOrEmpty(text);
char firstChar = text[0];
string substring = text.Substring(1, 3);
string replaced = text.Replace(""World"", ""C#"");
string upper = text.ToUpper();
string lower = text.ToLower();
bool startsWith = text.StartsWith(""H"");
bool endsWith = text.EndsWith(""!"");
string[] words = text.Split(' ');
int length = words.Length;
string joined = string.Join(""-"", words);
bool contains = text.Contains(""Hello"");
int index = text.IndexOf(""o"");
int lastIndex = text.LastIndexOf(""l"");
string trimmed = text.Trim();
string paddedLeft = text.PadLeft(20);
string paddedRight = text.PadRight(20);
int parsedInt = int.Parse(""123"");
bool tryParse = int.TryParse(""456"", out int parsedValue);
double doubleValue = double.Parse(""3.14"");
string formatted = string.Format(""{0:C}"", 123.45);
DateTime now = DateTime.Now;
DateTime tomorrow = now.AddDays(1);
TimeSpan duration = tomorrow - now;
bool isWeekend = now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday;
",

            @"// Block 2: Conditional Statements and Loops
if (isGreater)
{
    Console.WriteLine(""a is greater than b"");
}
else if (isLess)
{
    Console.WriteLine(""a is less than b"");
}
else
{
    Console.WriteLine(""a is equal to b"");
}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($""Iteration {i}"");
}

int counter = 0;
while (counter < 5)
{
    Console.WriteLine(""Counter is "" + counter);
    counter++;
}

do
{
    Console.WriteLine(""Executed at least once"");
    counter--;
} while (counter > 0);

switch (now.DayOfWeek)
{
    case DayOfWeek.Monday:
        Console.WriteLine(""It's Monday!"");
        break;
    case DayOfWeek.Friday:
        Console.WriteLine(""It's Friday!"");
        break;
    default:
        Console.WriteLine(""It's a regular day."");
        break;
}

int[] numbersArray = { 1, 2, 3, 4, 5 };
foreach (int number in numbersArray)
{
    Console.WriteLine($""Number: {number}"");
}

int factorial = 1;
for (int i = 1; i <= 5; i++)
{
    factorial *= i;
}

bool found = false;
int searchValue = 3;
foreach (int number in numbersArray)
{
    if (number == searchValue)
    {
        found = true;
        break;
    }
}

string dayMessage = now.DayOfWeek switch
{
    DayOfWeek.Monday => ""Start of the week!"",
    DayOfWeek.Friday => ""Almost weekend!"",
    _ => ""Midweek.""
};
",

            @"// Block 5: LINQ Queries and Delegates
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
var oddNumbers = from n in numbers
                 where n % 2 != 0
                 select n;

int sumOfEvens = evenNumbers.Sum();
int productOfOdds = oddNumbers.Aggregate(1, (acc, n) => acc * n);

var squares = numbers.Select(n => n * n);
var orderedNumbers = numbers.OrderByDescending(n => n);

bool allPositive = numbers.All(n => n > 0);
bool anyNegative = numbers.Any(n => n < 0);
int maxNumber = numbers.Max();
int minNumber = numbers.Min();

var numbersWithIndexes = numbers.Select((n, index) => new { Number = n, Index = index });

Action<string> printAction = message => Console.WriteLine(message);
Func<int, int, int> addFunction = (x, y) => x + y;
Predicate<int> isEvenPredicate = n => n % 2 == 0;

List<int> numberList = new List<int> { 1, 2, 3, 4, 5 };
numberList.ForEach(n => Console.WriteLine($""Number: {n}""));

Dictionary<string, int> nameAgeDictionary = new Dictionary<string, int>
{
    { ""Alice"", 30 },
    { ""Bob"", 25 }
};
int aliceAge = nameAgeDictionary[""Alice""];
bool containsBob = nameAgeDictionary.ContainsKey(""Bob"");

List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
var distinctNumbers = numbers.Distinct().ToList();
var firstTwoNumbers = numbers.Take(2).ToList();
var skippedNumbers = numbers.Skip(2).ToList();

var combinedList = evenNumbers.Concat(oddNumbers).ToList();"
        };

        public static readonly string[] ExampleStrings = TestStrings.Concat(ChatGptExamples).ToArray();
    }
}
