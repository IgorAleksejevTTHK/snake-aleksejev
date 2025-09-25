
class AudioManager

{
    public void PlayEatSound()
    {
        Console.Beep(1000, 100); // короткий звуковой сигнал
    }

    public void PlayGameOverSound()
    {
        Console.Beep(500, 500);
        Console.Beep(300, 700);
    }
}