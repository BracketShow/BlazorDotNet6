namespace BlazorDotNet6Prerendered.Client.Components;

public partial class CounterComponent
{
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;

        if (currentCount > 5)
            throw new Exception("too big");
    }
}
