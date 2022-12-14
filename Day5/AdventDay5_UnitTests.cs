namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    private readonly AdventDay5 _adventDay5 = new();

    [Fact]
    public void You_can_get_current_cargo_state()
    {
        Assert.NotNull(_adventDay5.GetCargo().ReturnValue);
    }
    
    [Fact]
    public void cargo_state_contains_list_of_stack()
    {
        Assert.IsAssignableFrom<IEnumerable<object>>(_adventDay5.GetCargo().ReturnValue);
    }

    [Fact]
    public void add_two_crate_to_first_stack_with_order_Z_and_N_then_pop_out_with_order_N_and_Z()
    {
        _adventDay5.AddCrateToStack(1, "Z");
        _adventDay5.AddCrateToStack(1, "N");
        
        Assert.Equal("N",_adventDay5.GetCargo().ReturnValue[0].Pop());
        Assert.Equal("Z",_adventDay5.GetCargo().ReturnValue[0].Pop());
    }
    
    [Fact]
    public void cargo_has_two_stacks_and_first_has_2_and_second_has_3_crates()
    {
        var firstStack = _adventDay5.GetCargo().GetStack(1);
        firstStack.AddCrate("Z");
        firstStack.AddCrate("N");
        
        var secondStack = _adventDay5.GetCargo().GetStack(2);
        firstStack.AddCrate("M");
        firstStack.AddCrate("C");
        firstStack.AddCrate("D");

        Assert.Equal(2,firstStack.Count);
        Assert.Equal(3,secondStack.Count);
        
    }
    
}