namespace scanner.Generics
{
    public class ScrapedLink
    {
        public string Href;
        
        public string Text;

        public override string ToString()
        {
            return Href + "\n\t" + Text;
        }
    }
}