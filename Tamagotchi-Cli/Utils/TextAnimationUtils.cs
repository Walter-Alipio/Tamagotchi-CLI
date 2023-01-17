

public class TextAnimationUtils
{
  public static void Blink(string text, int blinkCount = 5, int onTime = 500, int offTime = 200)
  {
    System.Console.Clear();
    System.Console.CursorVisible = false;
    for (int i = 0; i < blinkCount; i++)
    {
      System.Console.WriteLine(text);
      Thread.Sleep(onTime);
      System.Console.Clear();
      Thread.Sleep(offTime);
    }
    System.Console.WriteLine(text);
    System.Console.CursorVisible = true;
  }

  public static void AnimatingTyping(string text, int delay = 25)
  {

    for (int i = 0; i < text.Length; i++)
    {
      System.Console.Write(text[i]);
      Thread.Sleep(delay);

      if (Console.KeyAvailable)
      {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (keyInfo.Key == ConsoleKey.Enter)
        {
          System.Console.Write(text.Substring(i + 1));
          break;
        }
      }
    }

  }

  public static void AnimateFrames(string[] frames, int repeat = 5, int delay = 100)
  {
    System.Console.CursorVisible = false;
    for (int i = 0; i < repeat; i++)
    {
      foreach (var frame in frames)
      {
        // System.Console.SetCursorPosition(0, 0);
        System.Console.Clear();
        System.Console.WriteLine(frame);
        Thread.Sleep(delay);
      }
    }
    System.Console.CursorVisible = true;
  }

}