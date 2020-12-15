using System.IO;

namespace Challenge13
{
    public static class Input
    {
        public static ShuttleBusData GetFromFile(string filename)
        {
            var data = File.ReadAllText(filename);
            return new ShuttleBusData(data);
        }
    }
}