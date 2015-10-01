namespace CommandParser
{
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void AddValue(string str);
    }
}
