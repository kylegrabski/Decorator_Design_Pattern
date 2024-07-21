using Decorator_Design_Pattern.Interfaces;

namespace Decorator_Design_Pattern.Implementation.Decorators;

public class UserTaskDecorator : IUserTask
{
    protected IUserTask _task;

    protected UserTaskDecorator(IUserTask task)
    {
        _task = task;
    }

    public void Accept(IVisitor visitor)
    {
        _task.Accept(visitor);
    }

    public IEnumerable<string> Description { get; set; }
}