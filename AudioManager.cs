//не смог разобраться с библиотеками для звука, поэтому сделал так
class AudioManager

{
    public void PlayEatSound()
    {
        Console.Beep(1000, 100); 
    }

    public void PlayGameOverSound()
    {
        Console.Beep(500, 500);
        Console.Beep(300, 700);
    }
}