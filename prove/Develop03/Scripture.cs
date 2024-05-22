using System;
using System.Collections.Generic;
using System.Text;

class Scripture
{
    private string _name;
    private int _length;
    static private List<Word> _words = [];

    // Set Phrase
    public void SetPhrase(string id, string phrase){
        _name = id;
        string[] word_list = phrase.Split(" ");
        _length = word_list.Length;

        foreach(string item in word_list){
            Word word = new();
            word.SetWord(item);
            _words.Add(word);
        }
    }

    // Advance
    public void Advance(){
        var ran = new Random();
        int index = ran.Next(_words.Count());

        if(_words[index]._empty == false){
            _words[index].Empty();
        }
        else {
            while(_words[index]._empty == true){
                index = ran.Next(_words.Count());
            }
        }
    }
    
    // Display
    public void Display(){
        Console.SetCursorPosition(0,0);
        Console.WriteLine(_name);
        var builder = new StringBuilder();
        foreach(Word word in _words){
            builder.Append(word.GetWord());
            builder.Append(" ");
        }
        string Scripture = builder.ToString();
        Console.WriteLine($"{_name}\n{Scripture}");
    }

    // Get Length
    public int GetLength(){
        return _length;
    }
}

