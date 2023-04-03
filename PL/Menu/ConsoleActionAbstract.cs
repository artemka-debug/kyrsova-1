using BLL;

namespace kyrsova_1
{
    public abstract class ConsoleActionAbstract
    {
        public string Name { get; }

    public int Index { get; }
    
    protected ConsoleActionAbstract(string name, int index)
    {
        this.Name = name;
        this.Index = index;
    }
    
    public abstract void Execute(ConsoleHelpers consoleHelpers, FlatRepository flatRepository, VisitRepository visitRepository);
    }
}
