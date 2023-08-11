using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using MoneyManager.Models;

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

  private ObservableCollection<Type> GenereateTree(){
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
  public object? Selected{
    get => _selected;
    set => this.RaiseAndSetIfChanged(ref _selected, value);
  }
  

  public void Add(){
  }

  public void Remove(){
    switch(Selected){
      case Type type: 
        var allOfType = _transactions.Where(t => t.Type == type.TypeName).Distinct();
        foreach(var current in allOfType){
          _transactions.Remove(current);
        }
        break;
      case Transaction transaction:
        _transactions.Remove(transaction);
        Types = GenereateTree();
        break;
      default:
        return;
    }
  }

  public void ToggleDock()
  {
    _ = !ShowDock ? ToggleButton = "Close" : ToggleButton = "Add Expense";
    ShowDock = !ShowDock;
  }
}
