using Automatonymous;
using DDD.Base.Sagas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infrastructure.Sagas
{
  public class SagaManager<TSagaMachine, TSagaData> : ISagaManager where TSagaMachine : AutomatonymousStateMachine<TSagaData> where TSagaData : class, ISagaData, new()
  {
    private ISagaRepository<TSagaData> _sagaRepository;
    private Dictionary<Type, Func<object, string>> _correlationIdFuncs = new Dictionary<Type, Func<object, string>>();
    public TSagaMachine SagaMachine { get; private set; }

    public SagaManager(TSagaMachine sagaMachine, ISagaRepository<TSagaData> sagaRepository)
    {
      _sagaRepository = sagaRepository;
      SagaMachine = sagaMachine;
    }

    protected void CorrelateEvent<TEvent>(Func<TEvent, string> correlationIdFunc)
    {
      _correlationIdFuncs.Add(typeof(TEvent), e => correlationIdFunc((TEvent)e));
    }

    public void ProcessMessage<TMessage>(TMessage message)
    {
      Event<TMessage> @event = SagaMachine.Events.OfType<Event<TMessage>>().FirstOrDefault();

      TMessage eventData = message;

      string correlationId = _correlationIdFuncs[typeof(TMessage)](eventData);

      TSagaData sagaData = _sagaRepository.Load(correlationId);
      if (sagaData == null)
      {
        sagaData = new TSagaData();
      }

      SagaMachine.RaiseEvent(sagaData, @event, eventData);

      _sagaRepository.Save(correlationId, sagaData);
    }
  }
}