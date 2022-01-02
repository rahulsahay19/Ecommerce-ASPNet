using System;

namespace EventBus.Messages.Events
{ 
    // Base/common props for all the events
  public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
        public IntegrationBaseEvent(Guid id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;
        }

        //Co-relation Id
        public Guid Id { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
