public class KeyboardWatcher
{
    public KeyboardWatcher(Keys key, bool ctrlRequired, Action<string> callback)
    {
        HookManager.KeyDown += (sender, e) =>
        {
            if (e.KeyCode == key && (!ctrlRequired || Control.ModifierKeys.HasFlag(Keys.Control)))
                callback($"keyboard:ctrl+{key.ToString().ToLower()}");
        };
    }
}
