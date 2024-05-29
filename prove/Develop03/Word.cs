using System.Reflection.Metadata.Ecma335;
using System.Text;

class Word {
    private string _word;
    public bool _empty = false;

    // Sets the words
    public void SetWord(string word) 
    { 
        _word = word;
    }
    // Gets the words from scripture
    public string GetWord()
    {
        return _word;
    }
    //Make word show nothing - empty
    public void Empty()
    {
        var builder = new StringBuilder();
        
        foreach(var i in _word){
            builder.Append("_");
        }
        _word = builder.ToString();
        _empty = true;
    }
    public bool GetEmpty(){
        return _empty;
    }
}
