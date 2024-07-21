using Decorator_Design_Pattern.Implementation.Decorators;
using Decorator_Design_Pattern.Implementation.Domain;
using Decorator_Design_Pattern.Interfaces;

namespace Decorator_Design_Pattern.Implementation.Visitors;

public class UserTaskVisitor: IVisitor
{
    public void Visit(DeadlineTask deadlineTask)
    {
        var deadlinePassed = deadlineTask.IsDeadlinePassed();

        if (deadlinePassed)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Deadline has passed!");
        }
    }

    public void Visit(UserTaskDecorator userTask)
    {
        throw new NotImplementedException();
    }

    public void Visit(PriorityTask priorityTask)
    {
        Console.WriteLine("ITS A priorityTask VISIT!");
    }

    public void Visit(RecurringTask recurringTask)
    {
        Console.WriteLine("ITS A recurringTask VISIT!");
    }

    public void Visit(UserTask recurringTask)
    {
        Console.WriteLine("ITS A recurringTask VISIT!");
    }
}