using Decorator_Design_Pattern.Implementation.Domain;

namespace Decorator_Design_Pattern.Interfaces;

public interface ITaskScheduler
{
    void AddTask(UserTask userTask);

    UserTask? CheckDueTasks();

    bool UpdateTask(UserTask userTask);
}