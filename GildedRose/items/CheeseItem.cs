namespace GildedRose; 

public class CheeseItem : Item{
    public override void UpdateQuality(){
    if(Quality>49){return;}
    if(SellIn<0) Quality++; 
        Quality++;
    }
    public override void UpdateSellin(){
        SellIn=SellIn-1;
    }   
    
}