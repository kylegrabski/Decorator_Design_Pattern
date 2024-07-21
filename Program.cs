using Decorator_Design_Pattern.Enums;
using Decorator_Design_Pattern.Implementation.Decorators;
using Decorator_Design_Pattern.Implementation.Domain;
using Decorator_Design_Pattern.Implementation.Visitors;
using Decorator_Design_Pattern.Interfaces;
using Sharprompt;

var yesOrNo = new Dictionary<string, bool>()
{
    {"No", false},
    {"Yes", true},
};

Console.WriteLine("Let's Create A New Task!");
Console.WriteLine("Write A Description Of The Task");
var userInput = Console.ReadLine() ?? "";

IUserTask ourTask = new UserTask(userInput);

ourTask = ApplyPriorityTask(ourTask);
ourTask = ApplyRecurringTask(ourTask);
ourTask = ApplyDeadlineTask(ourTask);

var visitor = new UserTaskVisitor();



Console.WriteLine($"TASK ADDED! {string.Join("", ourTask.Description)}");

while (true)
{
    ourTask.Accept(visitor);
    // if (ourTask is DeadlineTask deadlineTask && deadlineTask.IsDeadlinePassed())
    // {
    //     var count = 0;
    //     while (count < 3)
    //     {
    //         count++;
    //         Console.ForegroundColor = ConsoleColor.White;
    //         Console.BackgroundColor = ConsoleColor.Red;
    //         Console.WriteLine("Deadline has passed!");
    //         Thread.Sleep(1000);
    //     }
    //     break;
    // }

    // if (ourTask is RecurringTask recurringTask && recurringTask.CountRecurrence())
    // {
    //     Console.WriteLine("RECUR!");
    //     break;
    // }
    
    Thread.Sleep(1000);
}

return;


IUserTask ApplyPriorityTask(IUserTask task)
{
    var priorityOptions = Enum.GetValues(typeof(PriorityEnum))
        .Cast<PriorityEnum>()
        .Where(e => e != PriorityEnum.PriorityAssigned)
        .Select(e => e.ToString())
        .ToArray();
    var priorityIndex = Prompt.Select("Select Priority: ", priorityOptions);
    var isPriority = Enum.Parse<PriorityEnum>(priorityIndex);
    return (isPriority & PriorityEnum.PriorityAssigned) != 0 ? new PriorityTask(task, isPriority) : task;
}

IUserTask ApplyRecurringTask(IUserTask task)
{
    var isRecurringKey = Prompt.Select("Should This Task Recur? ", yesOrNo.Keys.ToArray());
    var isRecurring = yesOrNo[isRecurringKey];
    if (!isRecurring) return task;

    var recurrenceInterval = Prompt.Input<int>("Enter the recurrence interval in seconds");
    var recurrenceCount = Prompt.Input<int>("Enter the total number of recurrences");
    return new RecurringTask(task, recurrenceInterval, recurrenceCount);
}

IUserTask ApplyDeadlineTask(IUserTask task)
{
    var isDeadlineKey = Prompt.Select("Is There A Deadline? ", yesOrNo.Keys.ToArray());
    var isDeadline = yesOrNo[isDeadlineKey];
    if (!isDeadline) return task;

    var deadline = Prompt.Input<int>("Enter the deadline in seconds");
    return new DeadlineTask(task, deadline);
}
