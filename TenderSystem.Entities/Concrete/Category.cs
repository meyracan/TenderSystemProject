using TenderSystem.Core.Entities;

namespace TenderSystem.Entities.Concrete
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }    

    }
}