namespace APIExamples.GUID
{
    public interface IGuidService
    {
        string GetGuid();
    }

    public class GuidService : IGuidService
    {
        private readonly string _guid;
        public GuidService()
        {
            _guid= Guid.NewGuid().ToString();
        }
        public string GetGuid() => _guid;
    }
}