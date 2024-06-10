class Activity
{
    protected int _duration;
    protected string _title;
    protected string _description;

    public Activity(int durParam, string titleParam, string descParam)
    {
        _duration = durParam;
        _title = titleParam;
        _description = descParam;
    }
}