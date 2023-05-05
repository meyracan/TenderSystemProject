using TenderSystem.Core.Entities;

namespace TenderSystem.Entities.Concrete
{
    public class TenderStatus:IEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; }  
    }
}