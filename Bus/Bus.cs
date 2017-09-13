using System.Windows.Input;

namespace Bus
{
  public class Bus
  {
    public static void RegisterCommandHandler<TCommand,TCommandHandler>() 
      where TCommandHandler: ICommandHandler<TCommand> 
      where TCommand: ICommand
    {
      //Registers listener for command
    }

    public static void RegisterEventListener<TEvent, TEventLister>()
      where TEventLister : IEventListener<TEvent>
      where TEvent : IEvent
    {
      //Registers listener for command
    }
  }
}