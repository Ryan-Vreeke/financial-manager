using Avalonia.Controls;
using System;
using MoneyManager.ViewModels;
using MoneyManager.Models;
using Type = MoneyManager.Models.Type;

namespace MoneyManager.Views;

public partial class MainWindow : Window
{
  private TreeView _transactionTree;
  private MainWindowViewModel _viewModel;

  public MainWindow()
  {
    InitializeComponent();

    //Adding viewmodel to DataContext
    _viewModel = new();
    _viewModel = new MainWindowViewModel();
    _viewModel.ShowDialogRequest += ShowDialogRequested;
    this.DataContext = _viewModel;
    
    //Getting Transaction Tree
    _transactionTree = this.FindControl<TreeView>("TransactionTree")!;
  }

  //EVENTS
  private void TransactionSelectionChanged(object sender, SelectionChangedEventArgs e)
  {
    if (_transactionTree.SelectedItem is Type || _transactionTree.SelectedItem is Transaction)
    {
      var viewModel = (MainWindowViewModel)this.DataContext!;
      viewModel.Selected = _transactionTree.SelectedItem;
    }
    else
    {
      System.Console.WriteLine("no");
    }
  }

  private void ShowDialogRequested(object sender, EventArgs e)
  {
    System.Console.WriteLine("Adding window open");
    var dialog = new AddExpenseDialog();
    dialog.Show();
  }
}
