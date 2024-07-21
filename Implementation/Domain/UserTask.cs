using Decorator_Design_Pattern.Implementation.Decorators;
using Decorator_Design_Pattern.Interfaces;

namespace Decorator_Design_Pattern.Implementation.Domain;

public class UserTask: IUserTask
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }

    public IEnumerable<string> Description { get; set; } = new List<string>();

    public UserTask(string taskDescription)
    {
        Description = Description.Append($"Task Description: {taskDescription} | ");
    }

    // public bool TryGetTotalRecurrenceCount(out int totalRecurrenceCount)
    // {
    //     totalRecurrenceCount = 0;
    //     return false;
    // }
}