using Decorator_Design_Pattern.Enums;
using Decorator_Design_Pattern.Interfaces;

namespace Decorator_Design_Pattern.Implementation.Decorators;

public class PriorityTask : IUserTask
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public IEnumerable<string> Description { get; set; }
    private readonly IUserTask _taskDecorator;
    public PriorityEnum Priority { get; set; }

    public PriorityTask(IUserTask taskDecorator, PriorityEnum priority)
    {
        _taskDecorator = taskDecorator;
        Priority = priority;
        Description = _taskDecorator.Description.Select(task => task);
        Description = Description.Append($"Priority Level: {Priority} | ");
    }
}