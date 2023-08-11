using Avalonia.Controls;
using MoneyManager.ViewModels;
using MoneyManager.Models;

namespace MoneyManager.Views;

public partial class MainWindow : Window
{
  private TreeView _transactionTree;
  public MainWindow()
  {
    InitializeComponent();
    _transactionTree = this.FindControl<TreeView>("TransactionTree")!;
  }

  //EVENTS
  private void TransactionSelectionChanged(object sender, SelectionChangedEventArgs e){
    if(_transactionTree.SelectedItem is Type || _transactionTree.SelectedItem is Transaction){
      var viewModel = (MainWindowViewModel)this.DataContext!;
      viewModel.Selected = _transactionTree.SelectedItem;
    }else{
      System.Console.WriteLine("no");
    }
  }
}
