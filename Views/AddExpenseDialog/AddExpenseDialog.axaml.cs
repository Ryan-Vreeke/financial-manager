using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MoneyManager.Views;

public partial class AddExpenseDialog : Window
{
    public AddExpenseDialog()
    {
      AvaloniaXamlLoader.Load(this);
    }
}
