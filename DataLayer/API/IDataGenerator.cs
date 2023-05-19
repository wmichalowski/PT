namespace DataLayer.API
{

    public abstract class IDataGenerator
    {
        public abstract void Generate(IDataRepository dataRepository);
    }
}