namespace SAM.Library
{
    public class RealNumber
    {
        public RealNumber(string num)
        {
            string[] numParts = num.Split(new[] {'.'}, 2);
            Integer = numParts[0];
            Fractional = numParts.Length>1 ? numParts[1] : "";
        }

        public string Integer{ get; private set; }

        public string Fractional { get; private set; }
    }
}