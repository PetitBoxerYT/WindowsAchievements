public sealed partial class ToastOverlay : UserControl
{
    public ToastOverlay()
    {
        InitializeComponent();
    }

    public async void Show(string title, string description)
    {
        Title.Text = title;
        Description.Text = description;

        Root.Visibility = Visibility.Visible;
        await Task.Delay(3000);
        Root.Visibility = Visibility.Collapsed;
    }
}
