namespace scanner.Contracts
{
    public interface IScanner
    {
        string Scrape(string uri);

        string Results();
    }
}