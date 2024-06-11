namespace Decorator_Design_Pattern.Enums;

[Flags]
public enum PriorityEnum
{
    None = 0,
    Low = 1,
    Medium = 2,
    High = 4,
    PriorityAssigned = Low | Medium | High
}