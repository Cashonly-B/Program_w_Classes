using System;

public abstract class Event
    {
        private string _title;
        private string _time;
        private string _description;
        private Address Address;
        private DateTime _date;


        protected Event(string title, string time, string description, Address address, DateTime date)
        {
            _title = title;
            _time = time;
            _description = description;
            Address = address;
            _date = date;
        }

        public string GetDetails() { return $"Title: {_title} \nDescriptionL {_description} \nDate: {_date} \nTime: {_time} \nAddress: {Address}"; }

        public string GetDescription() { return $"Type: {GetType().Name} \nTitle: {_title} \nDate: {_date}"; }
    }