using System;
using System.Collections.Generic;
using System.Text;

class Scripture()
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

    // Advance every keystroke
    public bool Advance(){
        var ran = new Random();
        int number = ran.Next(3);
        int index = 0;
        int previous_index = 0;
        bool empty = false;
        bool all_empty = true;

        do{ // Random Number
            ran = new Random(); 
            index = ran.Next(_words.Count());
            if(index == previous_index){
                while(index == previous_index){
                    index = ran.Next(_words.Count());
                }
            }
            // If word is empty
            empty = _words[index].GetEmpty();
            if(empty == false){
                _words[index].Empty();
            } else{
                foreach(Word word in _words){
                    if(word.GetEmpty() == false){ 
                        word.Empty();
                        all_empty = false;
                        break;
                        }
                }
                if(all_empty == true){
                    return true;
                } else {
                    return false;
                }
            }
            number -= 1;
            previous_index = index;
        }while(number > 0);
        return false;
        }
    
    // Display
    public void Display(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        // Console.WriteLine(_name);
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
    // Once all words empty
    public void Finish(){
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.WriteLine("Done!");
        // Thread.Sleep(3000);
        return;
    }
}

