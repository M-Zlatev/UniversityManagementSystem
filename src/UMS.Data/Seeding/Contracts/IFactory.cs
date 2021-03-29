namespace UMS.Data.Seeding.Contracts
{
    using System.Collections;

    public interface IFactory
    {
         ICollection CreateEntities();
    }
}
