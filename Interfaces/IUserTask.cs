namespace Decorator_Design_Pattern.Interfaces;

public interface IUserTask
{
    void Accept(IVisitor visitor);
    IEnumerable<string> Description { get; set; }
}