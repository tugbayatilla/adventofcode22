namespace AdventOfCode22;

public class UnitTest1
{
    private readonly AdventDay1 _adventDay1 = new();
    private const string FileName = "adventDay1_testData.data";

    [Fact]
    public void Day_Exist()
    {
        AdventDay1 adventDay1 = new();
        
        Assert.NotNull(adventDay1);
    }
    
    [Fact]
    public void Return_MostCalories_Exist()
    {
        Assert.Equal(0, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_To_An_Elf_returns_the_calories()
    {
        _adventDay1.AddCalories(100, 0);
        
        Assert.Equal(100, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_To_A_specific_Elf_returns_the_calories()
    {
        _adventDay1.AddCalories(100, 1);
        
        Assert.Equal(100, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_for_2_Elves_returns_most_calories()
    {
        _adventDay1.AddCalories(100, 0);
        _adventDay1.AddCalories(200, 1);
        
        Assert.Equal(200, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_for_2_Elves_multiple_calories_returns_most_calories()
    {
        _adventDay1.AddCalories(100, 0);
        _adventDay1.AddCalories(200, 0);
        
        _adventDay1.AddCalories(200, 1);
        _adventDay1.AddCalories(300, 1);

        Assert.Equal(500, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Empty_filePath_returns_zero_most_calories()
    {
        string fileName = "";
        string fileContent = _adventDay1.ReadDataFromFile(fileName);

        Assert.Equal("", fileContent);
    }

    [Fact]
    public void Valid_file_with_1_record_returns_100_as_most_calories()
    {
        string fileContent = _adventDay1.ReadDataFromFile(FileName);

        Assert.Equal("100", fileContent);
    }
    
    [Fact]
    public void Invalid_fileName_returns_zero_most_calories()
    {
        string fileContent = _adventDay1.ReadDataFromFile("xyz");

        Assert.Equal("", fileContent);
    }
    
    [Fact]
    public void Use_filecontent_as_data_for_inventory()
    {
        string fileContent = _adventDay1.ReadDataFromFile(FileName);

        _adventDay1.FillInventory(fileContent);
        
        Assert.Equal(100, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void File_contains_multiple_entires_for_One_Elf()
    {
        string fileContent = 
            @"100
              200";

        _adventDay1.FillInventory(fileContent);
        
        Assert.Equal(300, _adventDay1.GetMostCalories());
    }

}

public class AdventDay1
{
    private readonly Dictionary<int, List<int>> _inventory = new();

    public int GetMostCalories()
    {
        if (_inventory.Count == 0) return 0;
        
        return _inventory.Values.Select(p=>p.Sum()).Max();
    }

    public void AddCalories(int calories, int indexOfElf)
    {
        if (!_inventory.ContainsKey(indexOfElf))
        {
            _inventory.Add(indexOfElf, new List<int>());
        }
        _inventory[indexOfElf].Add(calories);
    }

    public string ReadDataFromFile(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return "";
        
        var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        var path = System.IO.Path.Combine(directory, fileName);

        if (!File.Exists(path)) return "";
        
        return File.ReadAllText(path);
    }

    public void FillInventory(string fileContent)
    {
        var split = fileContent.Split(System.Environment.NewLine);
        foreach (var s in split)
        {
            AddCalories(int.Parse(s), 0);    
        }
        
    }
}