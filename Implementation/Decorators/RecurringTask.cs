using Decorator_Design_Pattern.Interfaces;

namespace Decorator_Design_Pattern.Implementation.Decorators;

public class RecurringTask : UserTaskDecorator
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public IEnumerable<string?> Description { get; set; }
    private readonly IUserTask _taskDecorator;
    private int _recurrenceInterval { get; set; } // This will be in seconds for testing purposes
    private int _totalRecurrenceCount { get; set; }
    private int _currentRecurrenceCount = 0;

    public RecurringTask(IUserTask taskDecorator, int recurrenceInterval, int totalRecurrenceCount) : base(taskDecorator)
    {
        _taskDecorator = taskDecorator;
        _recurrenceInterval = recurrenceInterval;
        _totalRecurrenceCount = totalRecurrenceCount;
        Description = _taskDecorator.Description.Select(task => task);
        Description = Description.Append($"Task Recurs Every: {_recurrenceInterval} Seconds For a Total of {_totalRecurrenceCount} Time(s) |  ");
    }
    
    public bool CountRecurrence()
    {
        return true;
    }
}