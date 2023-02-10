namespace Inlämningsuppgift_Hangman;
public  class Words
{
    private readonly string[] _words = {
        "flower",
        "dragon",
        "house",
        "cat",
        "dog",
        "Donald Trump",
        "waterfall",
        "happy",
        "bank",
        "dreaming",
        "Malmö"
    };
    public string RandomWord
    {
        get
        {
            var rand = new Random().Next(0, _words.Length);
            return _words[rand];
        }
    }
}