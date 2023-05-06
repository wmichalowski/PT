using DataLayer.API;

namespace DataLayer.Implementation;

internal class DataContext : IDataContext
{
    internal List<IEvent> events = new();
    internal List<ILibraryState> states = new();
    internal List<IUsers> users = new();
}