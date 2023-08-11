using System.Collections.ObjectModel;

namespace MoneyManager.Models;

public class Type
{
  public string? TypeName {get; set;}
  public ObservableCollection<Transaction> Transactions {get; set;}
}

public class Transaction
{
  public Transaction(string name, string type, double cost)
  {
    _name = name;
    _type = type;
    _cost = cost;
  }

  private string _name = string.Empty;
  public string Name
  {
    get => _name;
    set { _name = value; }
  }

  private string _type = string.Empty;
  public string Type
  {
    get => _type;
    set { _type = value; }
  }

  private double _cost;
  public double Cost
  {
    get => _cost;
    set { _cost = value; }
  }

  public string Price{
    get => $"${Cost}";
  }
}
