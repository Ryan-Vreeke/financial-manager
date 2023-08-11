using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using MoneyManager.Models;
using System.Collections.Generic;

namespace MoneyManager.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  private ObservableCollection<Transaction> _transactions =
    new()
    {
      new Transaction("Rent", "COL", 800.00),
      new Transaction("Car", "CAR", 225.00),
      new Transaction("Food", "COL", 100.00),
      new Transaction("Pizza Hut", "Date Night", 24.58),
    };

  public MainWindowViewModel()
  {
    Types = GenereateTree();
  }

  private ObservableCollection<Type> GenereateTree()
  {
    ObservableCollection<Type> typeList = new();
    foreach (string type in _transactions.Select(t => t.Type).Distinct())
    {
      typeList.Add(
        new Type
        {
          TypeName = type,
          Transactions = new(_transactions.Where(t => t.Type == type).Distinct())
        }
      );
    }
    return typeList;
  }

  private ObservableCollection<Type> _types = new ObservableCollection<Type>();
  public ObservableCollection<Type> Types
  {
    get => _types;
    set => this.RaiseAndSetIfChanged(ref _types, value);
  }

  private bool _showDock = false;
  public bool ShowDock
  {
    get => _showDock;
    set => this.RaiseAndSetIfChanged(ref _showDock, value);
  }

  private string _toggleButton = "Add Expense";
  public string ToggleButton
  {
    get => _toggleButton;
    set => this.RaiseAndSetIfChanged(ref _toggleButton, value);
  }

  private object? _selected = null;
  public object? Selected
  {
    get => _selected;
    set => this.RaiseAndSetIfChanged(ref _selected, value);
  }

  public void Add() { }

  public void Remove()
  {
    switch (Selected)
    {
      case Type type:
        var noTypeList = _transactions.ToList();
        noTypeList.RemoveAll(x => x.Type == type.TypeName);
        _transactions = new ObservableCollection<Transaction>(noTypeList);
        break;
      case Transaction transaction:
        _transactions.Remove(transaction);
        break;
      default:
        return;
    }
    Types = GenereateTree();
  }

  public void ToggleDock()
  {
    _ = !ShowDock ? ToggleButton = "Close" : ToggleButton = "Add Expense";
    ShowDock = !ShowDock;
  }
}
