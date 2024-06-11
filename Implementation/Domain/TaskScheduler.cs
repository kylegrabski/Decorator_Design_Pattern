using Decorator_Design_Pattern.Interfaces;

namespace Decorator_Design_Pattern.Implementation.Domain;

public class TaskScheduler : ITaskScheduler
{
    private readonly List<UserTask> _tasks = new List<UserTask>();

    public void AddTask(UserTask userTask)
    {
        throw new NotImplementedException();
    }

    public UserTask? CheckDueTasks()
    {
        throw new NotImplementedException();
    }

    public bool UpdateTask(UserTask userTask)
    {
        throw new NotImplementedException();
    }
}