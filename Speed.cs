class Speed
{
    private int delay;

    public Speed()
    {
        delay = 100; // начальная задержка в мс
    }

    public int GetDelay()
    {
        return delay;
    }

    public void IncreaseSpeed()
    {
        if (delay > 20)
            delay -= 30; // увеличиваем скорость (уменьшаем задержку)
    }

    public void Reset()
    {
        delay = 100;
    }
}