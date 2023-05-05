using TenderSystem.Core.Entities;

namespace TenderSystem.Entities.Concrete
{
    public class Client:User, IEntity
    {
        public string UserName { get; set; }    

    }
}
