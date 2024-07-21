using Decorator_Design_Pattern.Implementation.Decorators;
using Decorator_Design_Pattern.Implementation.Domain;

namespace Decorator_Design_Pattern.Interfaces;

public interface IVisitor
{
    void Visit(DeadlineTask deadlineTask);
    void Visit(UserTaskDecorator userTask);
    void Visit(PriorityTask priorityTask);
    void Visit(RecurringTask recurringTask);
    void Visit(UserTask recurringTask);
}