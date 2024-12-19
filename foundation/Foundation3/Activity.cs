abstract class Activity
{
    protected string _date;
    protected double _duration;
        
    public abstract double ReturnDistance();

    public abstract double ReturnSpeed();

    public abstract double ReturnPace();

    public abstract void Summary();
}

class Running : Activity
{
    private double _distance;

    public Running(string date, double duration, double distance)
    {
        _date = date;
        _duration = duration;
        _distance = distance;
    }

    public override double ReturnDistance()
    {
        return _distance;
    }

    public override double ReturnSpeed()
    {
        return _distance / _duration * 60;
    }

    public override double ReturnPace()
    {
        return _duration / _distance;
    }

    public override void Summary()
    {
        Console.WriteLine($"{_date} Running ({_duration} min) - Distance: {ReturnDistance().ToString("F2")} km, Speed: {ReturnSpeed().ToString("F2")} km/h, Pace: {ReturnPace().ToString("F2")} min/km");
    }
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, double duration, double speed)
    {
        _date = date;
        _duration = duration;
        _speed = speed;
    }

    public override double ReturnDistance()
    {
        return _speed * _duration / 60;
    }

    public override double ReturnSpeed()
    {
        return _speed;
    }

    public override double ReturnPace()
    {
        return 60 / _speed;
    }

    public override void Summary()
    {
        Console.WriteLine($"{_date} Cycling ({_duration} min) - Distance: {ReturnDistance().ToString("F2")} km, Speed: {ReturnSpeed().ToString("F2")} km/h, Pace: {ReturnPace().ToString("F2")} min/km");
    }
}

class Swimming : Activity
{
    private double _laps;

    public Swimming(string date, double duration, double laps)
    {
        _date = date;
        _duration = duration;
        _laps = laps;
    }

    public override double ReturnDistance()
    {
        return _laps * 50 / 1000;
    }

    public override double ReturnSpeed()
    {
        return ReturnDistance() / _duration * 60;
    }

    public override double ReturnPace()
    {
        return _duration / ReturnDistance();
    }

    public override void Summary()
    {
        Console.WriteLine($"{_date} Swimming ({_duration} min) - Distance: {ReturnDistance().ToString("F2")} km, Speed: {ReturnSpeed().ToString("F2")} km/h, Pace: {ReturnPace().ToString("F2")} min/km");
    }
}