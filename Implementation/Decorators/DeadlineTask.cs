using Decorator_Design_Pattern.Interfaces;

namespace Decorator_Design_Pattern.Implementation.Decorators;

public class DeadlineTask : IUserTask
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public IEnumerable<string> Description { get; set; }
    private readonly IUserTask _taskDecorator;
    private int _count { get; set; }
    private DateTimeOffset _deadline { get; set; }

    public DeadlineTask(IUserTask taskDecorator, int deadline)
    {
        _taskDecorator = taskDecorator;
        _deadline = DateTimeOffset.Now.AddSeconds(deadline); // Add Seconds for Testing Purposes
        Description = _taskDecorator.Description.Select(task => task);
        Description = Description.Append($"Deadline At: {_deadline} | ");
    }
    
    public bool IsDeadlinePassed()
    {
        return DateTimeOffset.Now >= _deadline;
    }
}