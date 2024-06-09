using Sharprompt;

var options = new[] { "Option 1", "Option 2", "Option 3" };
var selectedOption = Prompt.Select("Please select an option:", options);

Console.WriteLine($"You selected: {selectedOption}");
