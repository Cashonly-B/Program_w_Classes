using System;

public abstract class Event
    {
        private string _title { get; }
        private string _time { get; }
        private string _description { get; }
        private Address Address { get; }
        private DateTime _date { get; }


        protected Event(string title, string time, string description, Address address, DateTime date)
        {
            _title = title;
            _time = time;
            _description = description;
            Address = address;
            _date = date;
        }

        public string RegDetails() { return $"Title: {_title} \nDescriptionL {_description} \nDate: {_date} \nTime: {_time} \nAddress: {Address}"; }
        public abstract string FullDetails(); // ChatGPT helped me write this line
        public string GetDescription() { return $"Type: {GetType().Name} \nTitle: {_title} \nDate: {_date}"; }
    }