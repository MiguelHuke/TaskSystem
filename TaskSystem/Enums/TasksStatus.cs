using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TasksStatus
    {
        [Description("To do")]
        ToDo = 1,
        [Description("On going")]
        OnGoing = 2,
        [Description("Completed")]
        Completed = 3
    }
}
