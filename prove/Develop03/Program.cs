using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = [];
        bool forward = false;

        Scripture reference1 = new();
        string firstTimothy4_9 = "For bodily exercise profiteth little: but godliness is profitable unto all things, having promise of the life that now is, and of that which is to come.";
        reference1.SetPhrase("script",firstTimothy4_9);
        scriptures.Add(reference1);

        Scripture reference2 = new();
        string john10_7 = "Then said Jesus unto them again, Verily, verily, I say unto you, I am the door of the sheep.";
        reference2.SetPhrase("script",john10_7);
        scriptures.Add(reference2);

        Scripture reference3 = new();
        string mosiah4_9 = "Believe in God; believe that he is, and that he created all things, both in heaven and in earth; believe that he has all wisdom, and all power, both in heaven and in earth; believe that man doth not comprehend all the things which the Lord can comprehend.";
        reference3.SetPhrase("script",mosiah4_9);
        scriptures.Add(reference3);
        
        var ran = new Random();
        int index = ran.Next(scriptures.Count);
        Scripture selected = scriptures[index];
        selected.Display();
        while(selected.GetLength() > 0){
            Console.ReadKey();
            forward = selected.Advance();
            if(forward == false) { selected.Display(); }
            else { selected.Finish(); }
        }
    }
}