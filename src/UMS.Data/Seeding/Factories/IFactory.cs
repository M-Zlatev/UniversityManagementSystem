namespace UMS.Data.Seeding.Factories
{
    using System.Collections;

    public interface IFactory
    {
         ICollection CreateEntities();
    }
}
