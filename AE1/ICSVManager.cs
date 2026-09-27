namespace icsvmanager
{
    public interface ICSVManager
    {
        void writeToCSV(string filepath);
        void openCSV(string filepath);
    }
}